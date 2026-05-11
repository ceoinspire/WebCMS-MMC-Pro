using Dapper;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;

namespace MMC_Pro_Edition.Repository
{
    public class DashboardRepository
    {
        private readonly IConfiguration _config;
        private readonly Onedb _con;
        private readonly DapperContext _dapper;
        private readonly HelperMethods _helper = new HelperMethods();

        public DashboardRepository(IConfiguration config, Onedb con, DapperContext dapper)
        {
            _config = config;
            _con = con;
            _dapper = new DapperContext(_config);
        }
       
        public DashBoardSettings DashboardWidgets(int ContentId)
        {
            using (var con = _dapper.CreateConnection())
            {
                string query = $@"SELECT 
                            (SELECT COUNT(*) FROM WEBCMS.Content) AS TotalContent,
                            (SELECT COUNT(*) FROM WEBCMS.ContentType) AS ContentType,
                            (SELECT COUNT(*) FROM WEBCMS.ContentCategory) AS ContentCategory,
                            (SELECT COUNT(*) FROM WEBCMS.CmsEmail ) AS TotalEmails";

                var res = con.Query<DashBoardSettings>(query).FirstOrDefault();
                return res;
            }
        }

    }

    public class DashBoardSettings
    {
        public int TotalContent { get; set; }
        public int ContentType { get; set; }
        public int ContentCategory { get; set; }
        public int TotalEmails { get; set; }
    }

}
