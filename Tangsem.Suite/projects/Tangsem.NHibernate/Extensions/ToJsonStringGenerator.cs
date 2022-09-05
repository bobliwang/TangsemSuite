using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.Util;

namespace Tangsem.NHibernate.Extensions
{
  public class ToJsonStringGenerator : BaseHqlGeneratorForMethod
  {
    public ToJsonStringGenerator()
    {
      this.SupportedMethods = new[]
      {
        ReflectHelper.GetMethod(() => LinqFunctionExtensions.ToJsonString(null))
      };
    }

    public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
      ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
    {
      return visitor.Visit(arguments[0]);
    }
  }
}