using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using NHibernate;
using NHibernate.Dialect;
using NHibernate.Dialect.Function;
using NHibernate.Hql.Ast;
using NHibernate.Linq;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;
using NHibernate.Util;

using Tangsem.Common.Extensions;

namespace Tangsem.NHibernate.Extenstions
{
  public static class LinqFunctionExtensions
  {
    public static bool IsLike(this string source, string pattern)
    {
      pattern = Regex.Escape(pattern);
      pattern = pattern.Replace("%", ".*?").Replace("_", ".");
      pattern = pattern.Replace(@"\[", "[").Replace(@"\]", "]").Replace(@"\^", "^");

      return Regex.IsMatch(source, pattern);
    }

    public static int JsonArrayLength(this object[] source)
    {
      return source.Length;
    }

    public static bool AnyInJsonArray<T>(this T[] source, Expression<Func<T, bool>> expression)
    {
      if (source == null)
      {
        return false;
      }

      return source.AsQueryable().Any(expression);
    }

    public static string ToJsonString(this object source)
    {
      if (source == null)
      {
        return null;
      }

      return JsonConvert.SerializeObject(source);
    }
  }



  public class AnyInJsonArrayGenerator : BaseHqlGeneratorForMethod
  {
    public AnyInJsonArrayGenerator()
    {
      this.SupportedMethods = new[] { ReflectHelper.GetMethod(() => LinqFunctionExtensions.AnyInJsonArray<object>(null, null)) };
    }

    public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject,
      ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
    {

      var expr = arguments[0] as Expression<Func<object, object>>;
      var propertyName = expr.GetPropertyInfo().Name;

      var select = treeBuilder.Select(treeBuilder.Constant(1));
      //treeBuilder.From(treeBuilder.With())

      

      return treeBuilder.Like(visitor.Visit(arguments[0]).AsExpression(),
        visitor.Visit(arguments[1]).AsExpression());
    }
  }


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

  public class ExtendedLinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
  {
    public ExtendedLinqToHqlGeneratorsRegistry()
    {
      this.Merge(new JsonArrayLengthGenerator());
      this.Merge(new IsLikeGenerator());
      this.Merge(new IsNulOrEmptyGenerator());
      this.Merge(new IsNulOrWhitespaceGenerator());
      this.Merge(new ToJsonStringGenerator());
    }
  }


  public class MsSql2008DialectExt : MsSql2008Dialect
  {
    public MsSql2008DialectExt()
    {
      this.RegisterFunction("dbo.fn_GetJsonArrayLength", new StandardSQLFunction("dbo.fn_GetJsonArrayLength", NHibernateUtil.Int32));
    }
  }
}