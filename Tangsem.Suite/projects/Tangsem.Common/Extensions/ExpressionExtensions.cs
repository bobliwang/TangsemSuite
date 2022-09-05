using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Tangsem.Common.Extensions
{
	public static class ExpressionExtensions
	{
		public static MemberExpression GetMemberExpression<T>(this Expression<Func<T, object>> expression)
		{
      if (!(expression is LambdaExpression lambda))
			{
				throw new ArgumentNullException("T");
      }

      return GetMemberExpression(lambda);
    }

    public static PropertyInfo GetPropertyInfo<T>(this Expression<Func<T, object>> expression)
    {
      var memberExpr = expression.GetMemberExpression();
      return (PropertyInfo)memberExpr.Member;
    }

    public static FieldInfo GetFieldInfo<T>(this Expression<Func<T, object>> expression)
    {
      var memberExpr = expression.GetMemberExpression();
      return (FieldInfo)memberExpr.Member;
    }

    public static MemberExpression GetMemberExpression<T, TResult>(this Expression<Func<T, TResult>> expression)
    {
      if (!(expression is LambdaExpression lambda))
      {
        throw new ArgumentNullException("T");
      }

      return GetMemberExpression(lambda);
    }

    public static PropertyInfo GetPropertyInfo<T, TResult>(this Expression<Func<T, TResult>> expression)
    {
      var memberExpr = expression.GetMemberExpression();
      return (PropertyInfo) memberExpr.Member;
    }

    public static FieldInfo GetFieldInfo<T, TResult>(this Expression<Func<T, TResult>> expression)
		{
			var memberExpr = expression.GetMemberExpression();
			return (FieldInfo) memberExpr.Member;
		}

    private static MemberExpression GetMemberExpression(LambdaExpression lambda)
    {
      MemberExpression memberExpr = null;
      switch (lambda.Body.NodeType)
      {
        case ExpressionType.Convert:
          {
            if (!(lambda.Body is UnaryExpression unaryExpr))
            {
              throw new ArgumentNullException("The converter expression has to be unary.");
            }

            memberExpr = unaryExpr.Operand as MemberExpression;
            break;
          }
        case ExpressionType.MemberAccess:
          memberExpr = lambda.Body as MemberExpression;
          break;

        default:
          throw new NotSupportedException(
            $"{lambda.Body.NodeType} is not any one of the supported (ExpressionType.Convert | ExpressionType.MemberAccess) types");
      }

      return memberExpr ?? throw new ArgumentException("Not a member expression.");
    }
  }
}
