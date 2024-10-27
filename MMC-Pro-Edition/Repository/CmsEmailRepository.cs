using Dapper;
using EmailHandler.Repository;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;

namespace MMC_Pro_Edition.Repository
{
	public class CmsEmailRepository
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		public CmsEmailRepository(IConfiguration config, Onedb con)
		{
			_config = config;
			_con = con;
			_dapper = new DapperContext(_config);
		}


		public DTOCMSEmail Emails(int WebsiteId, int pageNumber, string searchQuery, int pageSize, string orderBy, bool ascending)
		{
			using (var con = _dapper.CreateConnection())
			{
				DTOCMSEmail emailDto = new DTOCMSEmail();

				// Base query for email selection
				string query = $@"SELECT * FROM webcms.cmsemail WHERE WebsiteId = @WebsiteId";

				// Apply search filtering if provided
				if (!string.IsNullOrEmpty(searchQuery))
				{
					query += " AND (EmailSender LIKE @Search OR EmailSubject LIKE @Search OR FirstName LIKE @Search OR LastName LIKE @Search)";
				}

				// Determine the order direction
				string orderDirection = ascending ? "ASC" : "DESC";

				// Add order by clause to the query
				query += $" ORDER BY {orderBy} {orderDirection}";

				// Get total count of emails based on the search criteria
				string countQuery = $@"SELECT COUNT(1) FROM webcms.cmsemail WHERE WebsiteId = @WebsiteId";

				if (!string.IsNullOrEmpty(searchQuery))
				{
					countQuery += " AND (EmailSender LIKE @Search OR EmailSubject LIKE @Search OR FirstName LIKE @Search OR LastName LIKE @Search)";
				}

				// Set parameters for Dapper
				var parameters = new
				{
					WebsiteId = WebsiteId,
					Search = "%" + searchQuery + "%"
				};

				// Execute the count query
				emailDto.EmailCount = con.ExecuteScalar<int>(countQuery, parameters);

				// Now, adjust the original query to include pagination
				query += $" OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

				// Update parameters for pagination
				var parameterss = new
				{
					WebsiteId = WebsiteId,
					Search = "%" + searchQuery + "%",
					Offset = (pageNumber - 1) * pageSize,
					PageSize = pageSize
				};

				// Execute the query to fetch emails
				emailDto.Emails = con.Query<CMSEmailVM>(query, parameterss).ToList();

				return emailDto;
			}
		}




		public CMSEmailVM SingleEmail(int WebsiteId, int EmailId)
		{
			// Find the email based on the given conditions
			var email = _con.CmsEmail.FirstOrDefault(x => x.WebsiteId == WebsiteId && x.EmailId == EmailId);

			if (email != null)
			{
				email.IsRead = true; 

				_con.SaveChanges();
				return new CMSEmailVM
				{
					EmailId = email.EmailId,
					EmailSender = email.EmailSender,
					EmailBody = email.EmailBody,
					EmailSubject = email.EmailSubject,
					IsSend = email.IsSend,
					DateCreated = email.DateCreated,
					FirstName = email.FirstName,
					LastName = email.LastName,
					FullName = email.FullName,
					Mobile = email.Mobile,
					LandLine = email.LandLine
				};
			}
			return null;
		}

		public bool RemoveEmails(DTOCMSEmail model)
		{
			using (var con = _dapper.CreateConnection())
			{
				con.Open();
				using (var transaction = con.BeginTransaction())
				{
					try
					{
						var ss = model.Emails;
						string emailIds = string.Join(", ", ss.Select(e => $"'{e.EmailId}'"));
						string query = $"DELETE FROM Webcms.CmsEmail WHERE EmailId IN ({emailIds})";
						string queryTwo = $"DELETE FROM Webcms.CmsEmailAttachments where EmailId in ({emailIds})";
						int affectedRowsOne = con.Execute(queryTwo, transaction: transaction);

						int affectedRows = con.Execute(query, transaction: transaction);

						transaction.Commit();

						return affectedRows > 0;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						return false;
					}
				}
			}
		}

		public bool UpdateSendRecord(int Id)
		{
			var res = _con.CmsEmail.Where(x => x.EmailId == Id).FirstOrDefault();
			res.IsSend = true;
			_con.CmsEmail.Update(res);
			_con.SaveChanges();
			return true;
		}

		public void SendNotSentEmail()
		{
			var e = _con.CmsEmail.Where(x => x.IsSend == false || x.IsSend == null).FirstOrDefault();
			if (e!=null)
			{
				if (!string.IsNullOrEmpty(e.EmailSender))
				{
					MailService mailService = new MailService(_config);
					MailData m = new MailData();
					m.ToEmail = e.EmailSender;
					m.EmailBody = e.EmailBody;
					m.EmailSubject = e.EmailSubject;
					m.ToName = "Company";
					mailService.SendMail(m);
					UpdateSendRecord(e.EmailId);

				}
			}
			
		
		}



	}
}
