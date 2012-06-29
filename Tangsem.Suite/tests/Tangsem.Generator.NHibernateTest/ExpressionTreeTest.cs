﻿using System;
using System.Linq.Expressions;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tangsem.Common.Extensions;
using Tangsem.Generator.NHibernateTest.Domain.Entities;
using Tangsem.Generator.NHibernateTest.Domain.Repositories;

namespace Tangsem.Generator.Test
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
