using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using NHibernate.Hql.Ast;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.Util;

namespace Tangsem.NHibernate.Extenstions
{
  public class JsonArrayLengthGenerator : BaseHqlGeneratorForMethod
  {
    public JsonArrayLengthGenerator()
    {
      this.SupportedMethods = new[]
      {
        ReflectHelper.GetMethod(() => LinqFunctionExtensions.JsonArrayLength(null))
      };
    }

    public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
      ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
    {
      var args = arguments.Select(a => visitor.Visit(a)).Cast<HqlExpression>();


      return treeBuilder.MethodCall("dbo.fn_GetJsonArrayLength", args);
    }
  }
}