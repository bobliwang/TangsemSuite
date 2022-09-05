using System.IO;
using System.IO.Compression;
using System.Text;

namespace Tangsem.Common.Extensions
{
  public static class CompressionExtensions
  {
    public static byte[] ToDecompressedBytes(this byte[] compressedBytes)
    {
      using (var inStream = new MemoryStream(compressedBytes))
      using (var bigStream = new GZipStream(inStream, CompressionMode.Decompress))
      using (var bigStreamOut = new MemoryStream())
      {
        bigStream.CopyTo(bigStreamOut);

        return bigStreamOut.ToArray();
      }
    }

    public static string ToDecompressedString(this byte[] compressedBytes)
    {
      return Encoding.UTF8.GetString(compressedBytes.ToDecompressedBytes());
    }

    public static byte[] ToCompressedBytes(this byte[] bytes)
    {
      if (bytes == null || bytes.Length == 0)
      {
        return null;
      }

      using (var outStream = new MemoryStream())
      {
        using (var tinyStream = new GZipStream(outStream, CompressionMode.Compress))
        using (var mStream = new MemoryStream(bytes))
        {
          mStream.CopyTo(tinyStream);
        }

        return outStream.ToArray();
      }
    }

    public static byte[] ToCompressedBytes(this Stream inputStream)
    {
      using (var outStream = new MemoryStream())
      {
        using (var tinyStream = new GZipStream(outStream, CompressionMode.Compress))
        {
          inputStream.CopyTo(tinyStream);
        }

        return outStream.ToArray();
      }
    }

    public static byte[] ToCompressedBytes(this string inputString)
    {
      return Encoding.UTF8.GetBytes(inputString).ToCompressedBytes();
    }

  }
}