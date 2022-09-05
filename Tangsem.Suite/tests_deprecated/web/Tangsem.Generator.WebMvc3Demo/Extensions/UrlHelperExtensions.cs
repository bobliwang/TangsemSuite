using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tangsem.Generator.WebMvc3Demo.Extensions
{
  /// <summary>
  /// The extensions for UrlHelper.
  /// </summary>
  public static class UrlHelperExtensions
  {
    /// <summary>
    /// Compose a url based on ActionResult and route defaults.
    /// </summary>
    /// <param name="urlHelper">
    /// The url helper.
    /// </param>
    /// <param name="result">
    /// The result.
    /// </param>
    /// <param name="defaults">
    /// The defaults.
    /// </param>
    /// <returns>
    /// The url string.
    /// </returns>
    public static string Action(this UrlHelper urlHelper, ActionResult result, object defaults)
    {
      // Start by adding the default values from the anonymous object (if any)
      var routeValues = new RouteValueDictionary(defaults);

      // Then add the Controller/Action names and the parameters from the call
      foreach (var pair in result.GetRouteValueDictionary())
      {
        routeValues.Add(pair.Key, pair.Value);
      }

      var url = urlHelper.RouteUrl(routeValues);

      return url;
    }
  }
}