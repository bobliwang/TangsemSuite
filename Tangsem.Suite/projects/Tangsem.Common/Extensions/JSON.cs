using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Tangsem.Common.Extensions
{
  public static class JSON
  {
    public static string Stringify(object obj, JsonSerializerSettings settings = null)
    {
      return JsonConvert.SerializeObject(obj, settings ?? JsonSettings.Default);
    }

    public static T Parse<T>(string jsonText, JsonSerializerSettings settings = null)
    {
      return JsonConvert.DeserializeObject<T>(jsonText, settings ?? JsonSettings.Default);
    }
  }

  public static class JsonSettings
  {
    public static JsonSerializerSettings Default => GetDefaultSerializerSettings();

    public static JsonSerializerSettings GetDefaultSerializerSettings()
    {
      return new JsonSerializerSettings
               {
                 Formatting = Formatting.None,
                 ContractResolver = new CamelCasePropertyNamesContractResolver
                                      {
                                        NamingStrategy =
                                          {
                                            ProcessDictionaryKeys = false
                                          }
                                      },
                 NullValueHandling = NullValueHandling.Ignore,

                 // https://www.hanselman.com/blog/OnTheNightmareThatIsJSONDatesPlusJSONNETAndASPNETWebAPI.aspx
                 // Nick Berardi - Tuesday, 6 March 2012 1:46:45 PM UTC
                 // To clarify my comment from above, the only DateTime formatter that follows ISO 8601 is "o". But the industry as a whole, as pretty much settled on millisecond resolution for the DateTime format, mostly because this is the resolution of UNIX time.
                 // It would be great if Microsoft also supported this.
                 // yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffzzz (this is the "o" format, which is ISO 8601)
                 // yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z' (this is the industry standard ISO 8601 format)
                 // It would save me a lot of time trying to create the most usable API across web clients, if Microsoft out of the box just supported this second format.
                 ////DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"
               };
    }
  }
}
