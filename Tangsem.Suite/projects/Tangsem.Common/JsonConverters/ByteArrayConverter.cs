using System;
using Newtonsoft.Json;
using Tangsem.Common.Extensions;

namespace Tangsem.Common.JsonConverters
{
  public class ByteArrayConverter : JsonConverter
  {
    public override bool CanRead => false;

    public override bool CanWrite => true;

    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof(byte[]);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      if (value is byte[] arr)
      {
        writer.WriteValue(arr.ByteArrayToHexString());
      }
    }
  }
}
