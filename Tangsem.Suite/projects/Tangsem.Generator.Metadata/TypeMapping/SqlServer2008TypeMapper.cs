using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tangsem.Generator.Metadata.TypeMapping
{
  public class SqlServer2008TypeMapper : TypeMapper
  {
    protected override IDictionary<string, Type> InitMappings()
    {
      var typeMapper = new Dictionary<string, Type>();

      typeMapper["bigint"] = typeof(long);
      typeMapper["binary"] = typeof(byte[]);
      typeMapper["bit"] = typeof(bool);
      typeMapper["char"] = typeof(string);
      typeMapper["date"] = typeof(DateTime);
      typeMapper["datetime"] = typeof(DateTime);
      typeMapper["datetime2"] = typeof(DateTime);
      typeMapper["decimal"] = typeof(decimal);
      typeMapper["varbinary"] = typeof(byte[]);
      typeMapper["float"] = typeof(double);
      typeMapper["image"] = typeof(byte[]);
      typeMapper["int"] = typeof(int);
      typeMapper["money"] = typeof(decimal);
      typeMapper["nchar"] = typeof(string);
      typeMapper["ntext"] = typeof(string);
      typeMapper["numeric"] = typeof(decimal);
      typeMapper["nvarchar"] = typeof(string);
      typeMapper["real"] = typeof(float);
      typeMapper["rowversion"] = typeof(byte[]);
      typeMapper["smalldatetime"] = typeof(DateTime);
      typeMapper["smallint"] = typeof(int);
      typeMapper["smallmoney"] = typeof(decimal);
      typeMapper["text"] = typeof(string);
      typeMapper["timestamp"] = typeof(byte[]);
      typeMapper["tinyint"] = typeof(byte);
      typeMapper["uniqueidentifier"] = typeof(Guid);
      typeMapper["varbinary"] = typeof(byte[]);
      typeMapper["varchar"] = typeof(string);

      typeMapper["xml"] = typeof(string);

      return typeMapper;
    }
  }
}
