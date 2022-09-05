using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.Util;

namespace Tangsem.NHibernate.Extensions
{
  public class IsNulOrEmptyGenerator : BaseHqlGeneratorForMethod
  {
    public IsNulOrEmptyGenerator()
    {
      this.SupportedMethods = new[]
      {
        ReflectHelper.GetMethod(() => string.IsNullOrEmpty(null))
      };
    }

    public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
      ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
    {
      var expr1 = treeBuilder.IsNull(visitor.Visit(arguments[0]).AsExpression());
      var expr2 = treeBuilder.Equality(visitor.Visit(arguments[0]).AsExpression(), treeBuilder.Constant(""));


      return treeBuilder.BooleanOr(expr1, expr2);
    }
  }
}