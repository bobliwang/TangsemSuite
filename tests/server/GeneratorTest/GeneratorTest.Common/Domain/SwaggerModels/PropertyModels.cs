
using System;

namespace GeneratorTest.Common.Domain.SwaggerModels
{
  public class Property
  {
    public int PropertyId { get; set; }

    public Guid PropertyGuidId { get; set; }

    public string AddressLine1 { get; set; }

    public string Suburb { get; set; }

    public string PostCode { get; set; }

    public PropertyType PropertyType { get; set; }

    public Person Landlord { get; set; }

    public DateTime LeaseStartDate { get; set; }

    public bool Leased { get; set; }
  }

  public class PropertyUpdatePayload
  {
    public Property Property { get; set; }

    public string ExtraInfo { get; set; }
  }

  public class Person
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }


    public Gender Gender { get; set; }
  }


  public enum Gender
  {
    Female = 0,

    Male = 1,

    BI
  }

  public enum PropertyType
  {

    UnknownPropertyType = 0,

    Residential,

    Business,

  }
}