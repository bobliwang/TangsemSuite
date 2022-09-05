using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Tangsem.Common.Extensions
{
  public static class MD5Extensions
  {
    public static string GetMD5HashBase64(this Stream stream)
    {
      if (stream == null)
      {
        return null;
      }

      using (var md5 = MD5.Create())
      {
        var hash = md5.ComputeHash(stream);
        return Convert.ToBase64String(hash);
      }
    }

    public static string GetMD5HashBase64(this byte[] data)
    {
      if (data == null)
      {
        return null;
      }

      using (var md5 = MD5.Create())
      {
        var hash = md5.ComputeHash(data);
        return Convert.ToBase64String(hash);
      }
    }

    public static string GetMD5HashBase64(this string data)
    {
      if (data == null)
      {
        return null;
      }

      return Encoding.UTF8.GetBytes(data).GetMD5HashBase64();
    }

    public static string GetMD5HashHex(this byte[] data)
    {
      if (data == null)
      {
        return null;
      }

      using (var md5 = MD5.Create())
      {
        var hash = md5.ComputeHash(data);
        return hash.ByteArrayToHexString();
      }
    }

    public static string GetMD5HashHex(this string data)
    {
      if (data == null)
      {
        return null;
      }

      return Encoding.UTF8.GetBytes(data).GetMD5HashHex();
    }

    public static string ByteArrayToHexString(this byte[] array)
    {
      if (array == null)
        return null;

      var hex = new StringBuilder(array.Length * 2);
      foreach (var b in array)
        hex.AppendFormat("{0:x2}", b);

      return hex.ToString();
    }
  }
}
