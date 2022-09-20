using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tangsem.Generator.Metadata.TypeMapping;

namespace Tangsem.Generator.Metadata.Postgres
{
  public class PostgreSQL12TypeMapper : TypeMapper
  {
    protected override IDictionary<string, Type> InitMappings()
    {
      var typeMapper = new Dictionary<string, Type>();

      typeMapper["bigint"] = typeof(long);
      typeMapper["bytea"] = typeof(byte[]);
      //typeMapper["bit"] = typeof(bool);
      typeMapper["boolean"] = typeof(bool);
      typeMapper["character"] = typeof(string);
      typeMapper["date"] = typeof(DateTime);
      typeMapper["timestamp"] = typeof(DateTime);
      typeMapper["timestamp without time zone"] = typeof(DateTime);
      typeMapper["timestamp with time zone"] = typeof(DateTime);

      typeMapper["decimal"] = typeof(decimal);
      typeMapper["varbinary"] = typeof(byte[]);
      typeMapper["integer"] = typeof(int);
      typeMapper["money"] = typeof(decimal);
      typeMapper["nchar"] = typeof(string);

      typeMapper["numeric"] = typeof(decimal);
      typeMapper["nvarchar"] = typeof(string);
      typeMapper["real"] = typeof(float);
      typeMapper["smallint"] = typeof(int);
      typeMapper["text"] = typeof(string);
      typeMapper["tinyint"] = typeof(byte);
      typeMapper["uuid"] = typeof(Guid);
      typeMapper["varbinary"] = typeof(byte[]);
      typeMapper["character varying"] = typeof(string);

      typeMapper["xml"] = typeof(string);
      typeMapper["json"] = typeof(string);

      return typeMapper;
    }
  }
}
