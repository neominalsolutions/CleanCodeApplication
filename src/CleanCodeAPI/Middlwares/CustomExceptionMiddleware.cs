namespace CleanCodeAPI.Middlwares
{
  public class CustomExceptionMiddleware
  {

    private readonly RequestDelegate _requestDelegate;

    public CustomExceptionMiddleware(RequestDelegate requestDelegate)
    {
      this._requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _requestDelegate(httpContext);
        // isteğin diğer middleware devretilmesi için RequestDelegate kullanıyoruz.
      }
      catch (Exception)
      {

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(new { Message = "Internal Server Error" });
      }

    }
  }
}
