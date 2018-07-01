using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.Util;

namespace Tangsem.NHibernate.Extenstions
{
  public class IsNulOrWhitespaceGenerator : BaseHqlGeneratorForMethod
  {
    public IsNulOrWhitespaceGenerator()
    {
      this.SupportedMethods = new[]
      {
        ReflectHelper.GetMethod(() => string.IsNullOrWhiteSpace(null))
      };
    }

    public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
      ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
    {
      var expr1 = treeBuilder.IsNull(visitor.Visit(arguments[0]).AsExpression());
      var expr2 = treeBuilder.MethodCall("LTRIM", visitor.Visit(arguments[0]).AsExpression());
      var expr3 = treeBuilder.Equality(expr2, treeBuilder.Constant(""));

      return treeBuilder.BooleanOr(expr1, expr3);
    }
  }
}