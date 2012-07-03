using System;
using System.Collections.Generic;

namespace Tangsem.Common.Extensions
{
  public static class ObjectExtension
  {
    public static List<T> AsList<T>(this T obj)
    {
      return new List<T> { obj };
    }

    ////public static void Test()
    ////{
    ////  var typeMapper = new Dictionary<string, Type>();

    ////  typeMapper["bigint"]           = typeof(long);
    ////  typeMapper["binary"]           = typeof(byte[]);
    ////  typeMapper["bit"]              = typeof(bool);
    ////  typeMapper["char"]             = typeof(string);
    ////  typeMapper["date"]             = typeof(DateTime);
    ////  typeMapper["datetime"]         = typeof(DateTime);
    ////  typeMapper["decimal"]          = typeof(decimal);
    ////  typeMapper["varbinary"]        = typeof(byte[]);
    ////  typeMapper["float"]            = typeof(double);
    ////  typeMapper["image"]            = typeof(byte[]);
    ////  typeMapper["int"]              = typeof(int);
    ////  typeMapper["money"]            = typeof(decimal);
    ////  typeMapper["nchar"]            = typeof(string);
    ////  typeMapper["ntext"]            = typeof(string);
    ////  typeMapper["numeric"]          = typeof(decimal);
    ////  typeMapper["nvarchar"]         = typeof(string);
    ////  typeMapper["real"]             = typeof(float);
    ////  typeMapper["rowversion"]       = typeof(byte[]);
    ////  typeMapper["smalldatetime"]    = typeof(DateTime);
    ////  typeMapper["smallint"]         = typeof(int);
    ////  typeMapper["smallmoney"]       = typeof(decimal);
    ////  typeMapper["text"]             = typeof(string);
    ////  typeMapper["timestamp"]        = typeof(byte[]);
    ////  typeMapper["tinyint"]          = typeof(byte);
    ////  typeMapper["uniqueidentifier"] = typeof(Guid);
    ////  typeMapper["varbinary"]        = typeof(byte[]);
    ////  typeMapper["varchar"]          = typeof(string);


    ////}



  }
}



