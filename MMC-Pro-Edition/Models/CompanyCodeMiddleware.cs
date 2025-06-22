namespace MMC_Pro_Edition.Models
{
    //public class CompanyCodeMiddleware
    //{

    //    private readonly RequestDelegate _next;

    //    public CompanyCodeMiddleware(RequestDelegate next)
    //    {
    //        _next = next;
    //    }
    //    public async Task Invoke(HttpContext context)
    //    {
    //        var queryCs = context.Request.Query["cs"].ToString();

    //        if (!string.IsNullOrEmpty(queryCs))
    //        {
    //            context.Session.SetString("CompanyCode", queryCs);
    //        }

    //        var companyCode = context.Session.GetString("CompanyCode");
    //        if (string.IsNullOrEmpty(companyCode))
    //        {
    //            context.Response.StatusCode = StatusCodes.Status400BadRequest;
    //            await context.Response.WriteAsync("Missing company code. Please use ?cs=yourdb once.");
    //            return;
    //        }

    //        await _next(context);
    //    }
    //}


}
