using EmailHandler.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;
using Mscc.GenerativeAI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Onedb>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

builder.Services.AddTransient<DapperContext, DapperContext>();
builder.Services.AddScoped<ContentRepository>();
builder.Services.AddHttpContextAccessor();
var apiKey = builder.Configuration.GetValue<string>("SystemSettings:GeminiAIKey");
builder.Services.AddSingleton(new GoogleAI(apiKey));
builder.Services.AddScoped<GeminiAIRepository>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = builder.Configuration.GetValue<string>("SystemSettings:CookieName");
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var cookieScheme = CookieAuthenticationDefaults.AuthenticationScheme + builder.Configuration.GetValue<string>("SystemSettings:CookieName");

builder.Services.AddAuthentication(cookieScheme).AddCookie(cookieScheme, options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.LoginPath = new PathString("/Accounts/Login");

    options.AccessDeniedPath = new PathString("/Accounts/Failure");

    options.ReturnUrlParameter = "returnUrl";
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    };
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.Name = cookieScheme;
    options.Events.OnValidatePrincipal = context =>
    {
        if (context.Principal == null || !context.Principal.Identity.IsAuthenticated)
        {
            context.RejectPrincipal();
            context.HttpContext.Response.Cookies.Delete(cookieScheme);
        }
        return Task.CompletedTask;
    };
    options.Events.OnSigningOut = context =>
    {
        context.HttpContext.Response.Cookies.Delete(cookieScheme);
        return Task.CompletedTask;
    };
});

builder.Services.AddTransient<MailService, MailService>();
builder.Services.AddTransient<CmsEmailRepository, CmsEmailRepository>();
builder.Services.AddInfrastructure();
var app = builder.Build();
app.UseStatusCodePagesWithReExecute("/Error/{0}");
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
AppDataUtility.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());

app.UseSession();
app.UseMiddleware<SessionValidationMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
