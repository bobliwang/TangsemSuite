using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Newtonsoft.Json;

using NJsonSchema;
using NJsonSchema.Generation;

using Tangsem.Common.Extensions;

using Xunit;

namespace Tangsem.Common.Tests
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      var schema = JsonSchema.FromType<Person>(new JsonSchemaGeneratorSettings
                                                  {
                                                    DefaultPropertyNameHandling = PropertyNameHandling.CamelCase
                                                  });
      
      var schemaData = schema.ToJson();
      var errors = schema.Validate("{ firstName: 'a', numberWithRange: 6 } ").ToList();
      
      foreach (var error in errors)
      {

      }

      //schema = await JsonSchema.FromJsonAsync(schemaData);
    }

    [Fact]
    public void Test_Expressions()
    {
      Expression<Func<Person, string>> firstNameExpr = p => p.FirstName;

      firstNameExpr.GetPropertyInfo().Name.Equals(nameof(Person.FirstName));

      Expression<Func<Person, object>> firstNameExpr1 = p => p.FirstName;

      firstNameExpr1.GetPropertyInfo().Name.Equals(nameof(Person.FirstName));
    }
  }

  public class Person
  {
    [Required]
    public string FirstName { get; set; }

    [Range(2, 5)]
    public int NumberWithRange { get; set; }
  }
}


