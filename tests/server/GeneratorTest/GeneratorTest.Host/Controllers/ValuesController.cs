using System;
using System.Collections.Generic;
using System.Linq;
using GeneratorTest.Common.Domain.SwaggerModels;
using GeneratorTest.Host.Infrastructure;

using Microsoft.AspNetCore.Mvc;

namespace GeneratorTest.Host.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    [HttpGet("properties/{postCode?}")]
    [Produces("application/json", Type = typeof(IEnumerable<Property>))]
    [AutoGenApiClient(new [] { "Tag" })]
    public IActionResult GetProperties(string postCode, string addressLine1, string suburb)
    {
      var props = new List<Property>();
      var landlord1 = new Person { FirstName = "Li", LastName = "Wang", Gender = Gender.Male };
      var landlord2 = new Person { FirstName = "Jack", LastName = "Chan", Gender = Gender.Male };

      props.Add(new Property
      {
        Landlord = landlord1,
        PropertyId = 1,
        PropertyGuidId = Guid.NewGuid(),
        AddressLine1 = "address line 1 value",
        Suburb = "Melbourne",
        PostCode = "3150",
        PropertyType = PropertyType.Residential
      });

      props.Add(new Property
      {
        Landlord = landlord2,
        PropertyId = 2,
        PropertyGuidId = Guid.NewGuid(),
        AddressLine1 = "address line 1 value",
        Suburb = "Glen Iris",
        PostCode = "3181",
        PropertyType = PropertyType.Business
      });

      if (string.IsNullOrEmpty(postCode))
      {
        return this.Ok(props);
      }

      return this.Ok(props.Where(x => x.PostCode.Contains(postCode)).ToList());
    }


    [HttpPost("properties/{propertyId}")]
    [Produces("application/json", Type = typeof(Property))]
    [AutoGenApiClient]
    public IActionResult UpdateProperty(int propertyId, Guid propertyGuidId, [FromBody] PropertyUpdatePayload propertyUpdatePayload)
    {
      var prop = propertyUpdatePayload.Property;
      prop.PropertyId = propertyId;
      prop.PropertyGuidId = propertyGuidId;

      return this.Ok(propertyUpdatePayload.Property);
    }

    // GET api/values
    [HttpGet]
    [Produces("application/json", Type = typeof(string[]))]
    [AutoGenApiClient]
    public IEnumerable<string> Get()
    {
      return new [] { "value1", "value2" };
    }

    ////// GET api/values/5
    ////[HttpGet("{id}")]
    ////public string Get(int id)
    ////{
    ////  return "value";
    ////}

    ////// POST api/values
    ////[HttpPost]
    ////public void Post([FromBody]string value)
    ////{
    ////}

    ////// PUT api/values/5
    ////[HttpPut("{id}")]
    ////public void Put(int id, [FromBody]string value)
    ////{
    ////}

    ////// DELETE api/values/5
    ////[HttpDelete("{id}")]
    ////public void Delete(int id)
    ////{
    ////}
  }
}
