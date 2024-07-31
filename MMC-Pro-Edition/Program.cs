using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Onedb>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddTransient<DapperContext, DapperContext>();
builder.Services.AddScoped<ContentRepository>();
builder.Services.AddSession(options =>
{
	options.Cookie.Name = "WEBCMS";
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme + "WEBCMS").AddCookie(
	CookieAuthenticationDefaults.AuthenticationScheme + "WEBCMS", option =>
	{
		option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
		option.SlidingExpiration = false;
		option.LoginPath = "/Accounts/Login";
		option.AccessDeniedPath = "/Accounts/Failure";
	});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.UseMiddleware<SessionValidationMiddleware>();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
