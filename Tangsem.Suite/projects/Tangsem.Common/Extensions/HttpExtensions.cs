using System.Net;

namespace Tangsem.Common.Extensions
{
  public static class HttpExtensions
  {
    public static bool IsSuccessCode(this HttpStatusCode statusCode)
    {
      return (int)statusCode >= 200 && (int)statusCode < 300;
    }
  }
}