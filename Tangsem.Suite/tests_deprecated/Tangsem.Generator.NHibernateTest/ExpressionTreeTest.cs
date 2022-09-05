using System;
using System.Linq.Expressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tangsem.Generator.WebMvc3Demo.Common.Domain.Entities;

namespace Tangsem.Generator.NHibernateTest
{
  [TestClass]
  public class ExpressionTreeTest
  {

    [TestMethod]
    public void Test_Expressions()
    {
      Expression<Predicate<Country>> expr = c => c.Name == "Australia" && c.CountryCode == "AU";

      Console.WriteLine(expr.ToString());
    }
  }
}
