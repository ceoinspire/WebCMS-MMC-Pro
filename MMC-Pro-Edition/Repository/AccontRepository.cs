using Dapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;
using System.Security.Claims;

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
                PersonId=x.PersonId
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
                new Claim("UserName",u.Person.FirstName),
                new Claim("UserEmail", u.UserName),
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
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1),
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.Now,
                RedirectUri = "/",
            };
            var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme + "WEBCMS");
            await httpcontext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme + "WEBCMS", new ClaimsPrincipal(identity), authProperties);
        }

    }
}
