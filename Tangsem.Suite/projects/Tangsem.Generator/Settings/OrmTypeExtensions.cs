using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tangsem.Generator.Settings
{
  public static class OrmTypeExtensions
  {
    public static string AsNamespacePart(this OrmTypes ormType)
    {
      switch(ormType)
      {
        case OrmTypes.NHibernate:
          return OrmTypes.NHibernate.ToString();
        case OrmTypes.EntityFramework:
          return "EF";
        default:
          throw new ArgumentOutOfRangeException("ormType");
      }
    }
  }
}
