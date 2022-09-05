using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.Util;

namespace Tangsem.NHibernate.Extensions
{
  public class IsLikeGenerator : BaseHqlGeneratorForMethod
  {
    public IsLikeGenerator()
    {
      this.SupportedMethods = new[] { ReflectHelper.GetMethod(() => LinqFunctionExtensions.IsLike(null, null)) };
    }

    public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
      ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
    {
      return treeBuilder.Like(visitor.Visit(arguments[0]).AsExpression(),
        visitor.Visit(arguments[1]).AsExpression());
    }
  }

  ////public class IsJsonStringLikeGenerator : BaseHqlGeneratorForMethod
  ////{
  ////  public IsJsonStringLikeGenerator()
  ////  {
  ////    this.SupportedMethods = new[] { ReflectHelper.GetMethod(() => LinqFunctionExtensions.IsJsonStringLike(null, null)) };
  ////  }

  ////  public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
  ////    ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
  ////  {
  ////    return treeBuilder.Like(visitor.Visit(arguments[0]).AsExpression(),
  ////      visitor.Visit(arguments[1]).AsExpression());
  ////  }
  ////}
}