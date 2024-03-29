﻿using NHibernate.Linq.Functions;

namespace Tangsem.NHibernate.Extensions
{
  public class ExtendedLinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
  {
    public ExtendedLinqToHqlGeneratorsRegistry()
    {
      this.Merge(new JsonArrayLengthGenerator());

      this.Merge(new IsLikeGenerator());
      ////this.Merge(new IsJsonStringLikeGenerator());

      this.Merge(new IsNulOrEmptyGenerator());
      this.Merge(new IsNulOrWhitespaceGenerator());


      this.Merge(new ToJsonStringGenerator());
    }
  }
}