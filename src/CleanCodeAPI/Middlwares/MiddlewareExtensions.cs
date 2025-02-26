namespace CleanCodeAPI.Middlwares
{
  public static class MiddlewareExtensions
  {

    public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<CustomExceptionMiddleware>();
    }

  }
}
