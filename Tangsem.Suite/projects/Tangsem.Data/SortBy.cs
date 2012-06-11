using System;

namespace Tangsem.Data
{
  public class SortBy<T> where T : class
  {
    public static SortBy<T> Create(Func<T, IComparable> propertyExpression, bool isDescending = false)
    {
      return new SortBy<T>(propertyExpression, isDescending);
    }

    public SortBy(Func<T, IComparable> propertyExpression, bool isDescending = false)
    {
      this.PropertyExpression = propertyExpression;
      this.IsDescending = isDescending;
    }

    /// <summary>
    /// Gets or sets the sorting property.
    /// </summary>
    public Func<T, IComparable> PropertyExpression { get; set; }

    /// <summary>
    /// Gets or sets whether sorting by descending order.
    /// </summary>
    public bool IsDescending { get; set; }
  }

  ////internal class Person
  ////{
  ////  public int Age { get; set; }

  ////  public string Name { get; set; }

  ////  public Person Parent { get; set; }
  ////}
}
