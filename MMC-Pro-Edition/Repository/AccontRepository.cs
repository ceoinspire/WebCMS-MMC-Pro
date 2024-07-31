using Dapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;
using System.Security.Claims;
using NuGet.Packaging;
using System.Drawing;

namespace MMC_Pro_Edition.Repository
{
	public class AccontRepository
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dap;
		public AccontRepository(IConfiguration config, Onedb con)
		{
			_config = config;
			_con = con;
			_dap = new DapperContext(_config);
		}
		public LoginVM ValidateLoginDetails(LoginVM model)
		{
			var con = _dap.CreateConnection();
			string encodedPass = EncryptionPasses.Encrypt(model.Password, PassesCore.INIT_VECTOR, PassesCore.PASS_PHRASE, PassesCore.KEY_SIZE);

			var query = $"select * from HRM.LoginUsers where UserName='{model.UserName}' and Passwords='{encodedPass}'";
			var result = con.Query<LoginVM>(query).Select(x => new LoginVM
			{
				UserName = x.UserName,
				Password = x.Password,
				Id = x.Id,
				PersonId = x.PersonId
			}).FirstOrDefault();
			if (result != null)
			{
				query = $"select * from SYSTEM.AssignedRoles ar join SYSTEM.Roles r on ar.RoleId=r.Id where ar.LoginId={result.Id}";
				var roles = con.Query<RolesVM>(query).Select(x => new RolesVM
				{
					Id = x.Id,
					Name = x.Name
				}).ToList();
				result.Roles = roles;
				query = $"SELECT * FROM HRM.Persons WHERE Id={result.PersonId}";
				var person = con.Query<PersonVM>(query).FirstOrDefault();
				result.Person = person;
			}
			return result;
		}

		public async Task SigninAsync(LoginVM u, HttpContext httpcontext)
		{
			List<Claim> Claims = new List<Claim> {
				new Claim("UserId",u.Id.ToString()),
				new Claim("UserName",u.Person.FirstName??""),
				new Claim("UserEmail", u.UserName??""),
				new Claim("ThemeStyle", "1"),
				new Claim(ClaimTypes.NameIdentifier,u.UserName),
				};
			foreach (var item in u.Roles)
			{
				var res = new Claim(ClaimTypes.Role, item.Name);
				Claims.Add(res);
			}
			var authProperties = new AuthenticationProperties
			{
				ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
				IsPersistent = true,
				IssuedUtc = DateTimeOffset.Now,
				RedirectUri = "/",
			};
			var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme + "WEBCMS");
			await httpcontext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme + "WEBCMS", new ClaimsPrincipal(identity), authProperties);
		}

		public List<LoginVM> GetAlUsers()
		{
			return _con.LoginUsers.Include("Person").Select(x => new LoginVM
			{
				UserName = x.UserName,
				Id = x.Id,
				Name = x.Person.FirstName
			}).ToList();
		}
		public bool AddUser(string email, string FirstName, string LastName, string Password, string mobile, string ImageUrl)
		{
			int maxId = 0;
			int personId = 0;
			int addressOne = 0;
			int assignRoleId = 0;
			if (_con.LoginUsers.Any())
			{
				maxId = _con.LoginUsers.Max(fm => fm.Id) + 1;
			}
			else
			{
				maxId = 1;
			}
			if (_con.Persons.Any())
			{
				personId = _con.Persons.Max(fm => fm.Id) + 1;
			}
			else
			{
				personId = 1;
			}
			if (_con.LaneAddresses.Any())
			{
				addressOne = _con.LaneAddresses.Max(fm => fm.AddressId) + 1;
			}
			else
			{
				addressOne = 1;
			}
			if (_con.AssignedRoles.Any())
			{
				assignRoleId = _con.AssignedRoles.Max(fm => fm.Id) + 1;
			}
			else
			{
				assignRoleId = 1;
			}


			int addressIdTwo = addressOne + 1;
			LoginUsers u = new LoginUsers();
			Persons p = new Persons();
			LaneAddresses addressBilling = new LaneAddresses();
			LaneAddresses addressShipping = new LaneAddresses();
			AssignedRoles ar = new AssignedRoles();
			Roles r = _con.Roles.Where(x => x.Name == "User").FirstOrDefault();
			Cities c = _con.Cities.Where(x => x.CityId == 1).FirstOrDefault();
			if (r != null)
			{
				ar.Id = assignRoleId;
				ar.RoleId = r.Id;
				ar.LoginId = maxId;
				ar.CreatedOn = DateTime.Now;
			}

			addressBilling.Area = "";
			addressBilling.FamousPlace = "";
			addressBilling.AddressType = "Billing";
			addressBilling.LaneAddressOne = "";
			addressBilling.LaneAddressTwo = "";
			addressBilling.AddressId = addressOne;
			addressShipping.Area = "";
			addressShipping.FamousPlace = "";
			addressShipping.AddressType = "Shipping";
			addressShipping.LaneAddressOne = "";
			addressShipping.LaneAddressTwo = "";
			addressShipping.AddressId = addressIdTwo;
			addressBilling.City = c;
			addressShipping.City = c;

			u.Id = maxId;
			p.Id = personId;
			u.UserName = email;
			u.Passwords = EncryptionPasses.Encrypt(Password, PassesCore.INIT_VECTOR, PassesCore.PASS_PHRASE, PassesCore.KEY_SIZE);
			p.FirstName = FirstName;
			p.LastName = LastName;
			p.Email = p.Email;
			p.Email = email;
			p.MobileNumber = mobile;
			p.ImageUrl = ImageUrl;
			u.Person = p;
			u.Person.LaneAddresses.Add(addressShipping);
			u.Person.LaneAddresses.Add(addressBilling);
			_con.Entry(c).State = EntityState.Unchanged;
			_con.LoginUsers.Add(u);
			_con.SaveChanges();

			_con.AssignedRoles.Add(ar);
			_con.SaveChanges();

			return true;
		}

		public LoginVM GetUserId(int Id)
		{
			return _con.LoginUsers.Include("Person").Where(x => x.Id == Id).Select(x => new LoginVM
			{
				UserName = x.UserName,
				Id = x.Id,
				IsActive = x.IsActive,
				Person = new PersonVM
				{
					FirstName = x.Person.FirstName,
					LastName = x.Person.LastName,
					MobileNumber = x.Person.MobileNumber,
					Email = x.Person.Email,
					Cnic = x.Person.Cnic,
					SocialSecurity = x.Person.SocialSecurity,
					Id = x.Person.Id,
					ImageUrl = x.Person.ImageUrl,
					Addresses = _con.LaneAddresses.Include("City").Include("City.Country").Where(z => z.PersonId == x.Person.Id).Select(y => new LaneAddressesVM
					{
						AddressId = y.AddressId,
						Area = y.Area,
						LaneAddressOne = y.LaneAddressOne,
						LaneAddressTwo = y.LaneAddressTwo,
						FamousPlace = y.FamousPlace,
						AddressType = y.AddressType,
						City = new CitiesVM { CityId = y.City.CityId, CityName = y.City.CityName, Country = new CountriesVM { CountryId = y.City.Country.CountryId, CountryName = y.City.Country.CountryName } }
					}).ToList()
				}

			}).FirstOrDefault();
		}
		public bool ActiveDeactiveUser(LoginVM model)
		{
			var user = _con.LoginUsers.Where(x => x.Id == model.Id).FirstOrDefault();
			if (model.Status.Equals("Active"))
			{
				user.IsActive = true;
			}
			else
			{
				user.IsActive = false;
			}
			_con.SaveChanges();
			return true;
		}
		public bool UpdateAccount(UpdateProfileVM model)
		{
			var user = _con.LoginUsers.Include("Person").Where(x => x.Id == model.Id).FirstOrDefault();
			user.UserName = model.Email;
			if (model.Password != null)
			{
				user.Passwords = EncryptionPasses.Encrypt(model.Password, PassesCore.INIT_VECTOR, PassesCore.PASS_PHRASE, PassesCore.KEY_SIZE);
			}
			user.Person.FirstName = model.FirstName;
			user.Person.LastName = model.LastName;
			user.Person.Email = model.Email;
			user.Person.Cnic = model.CNIC;
			user.Person.SocialSecurity = model.SocialSecurity;
			_con.SaveChanges();
			return true;
		}

		public bool UpdateProfilePhoto(FileUploadVM model)
		{
			string ImageUrl = new FileRepository().SaveImageMethod(model.File);
			var user = _con.LoginUsers.Include("Person").Where(x => x.Id == Convert.ToInt32(model.ContentId)).FirstOrDefault();
			user.Person.ImageUrl = ImageUrl;
			_con.SaveChanges();
			return true;
		}
		public List<CountriesVM> Countries()
		{
			var res = _con.Countries.Select(x => new CountriesVM
			{
				CountryId = x.CountryId,
				CountryName = x.CountryName
			}).ToList();
			return res;
		}

	}
}
