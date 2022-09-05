using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tangsem.Web.Mvc.Extensions
{
  /// <summary>
  /// The extensions for UrlHelper.
  /// </summary>
  public static class UrlHelperExtensions
  {
    /// <summary>
    /// Import css.
    /// </summary>
    /// <param name="url">
    /// The url helper.
    /// </param>
    /// <param name="cssFile">
    /// The css File.
    /// </param>
    /// <returns>
    /// The css link string. 
    /// </returns>
    public static string ImportCss(this UrlHelper url, string cssFile)
    {
      return url.Link(cssFile, "stylesheet", "text/css");
    }

    /// <summary>
    /// Import javascript.
    /// </summary>
    /// <param name="url">
    /// The url helper.
    /// </param>
    /// <param name="javascriptFile">
    /// The js file.
    /// </param>
    /// <returns>
    /// The js element.
    /// </returns>
    public static string ImportJs(this UrlHelper url, string javascriptFile)
    {
      var format = "<script type=\"text/javascript\" src=\"{0}\"></script>" + Environment.NewLine;

      return string.Format(format, url.Content(javascriptFile));
    }

    /// <summary>
    /// Render an link element.
    /// </summary>
    /// <param name="url">
    /// The url helper.
    /// </param>
    /// <param name="href">
    /// The href value.
    /// </param>
    /// <param name="rel">
    /// The rel value.
    /// </param>
    /// <param name="type">
    /// The type value.
    /// </param>
    /// <returns>
    /// The link string.
    /// </returns>
    public static string Link(this UrlHelper url, string href, string rel = "stylesheet", string type = "text/css")
    {
      var format = "<link href=\"{0}\" rel=\"{1}\" type=\"{2}\"/>" + Environment.NewLine;

      return string.Format(format, href, rel, type);
    }
  }
}
