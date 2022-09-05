using Microsoft.OpenApi;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Writers;

namespace Tangsem.OpenApi.Extensions.SwaggerCodeGen
{
  /// <summary>
  /// OpenApi Extension for generated code.
  /// </summary>
  public class OpenApiGeneratedCode : IOpenApiExtension
  {
    public OpenApiGeneratedCode(string code)
    {
      this.Code = code;
    }

    /// <summary>
    /// Creates OpenApiGeneratedCode from code.
    /// </summary>
    public static OpenApiGeneratedCode FromCode(string code) => new OpenApiGeneratedCode(code);

    public string Code { get; }

    public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
    {
      writer.WriteValue(this.Code);
    }
  }
}
