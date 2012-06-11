using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Tangsem.Common.Extensions
{
	public static class ExpressionExtensions
	{
		public static MemberExpression GetMemberExpression<T>(this Expression<Func<T, object>> expression)
		{
			var lambda = expression as LambdaExpression;
			if (lambda == null)
			{
				throw new ArgumentNullException("T");
			}

			MemberExpression memberExpr = null;
			if (lambda.Body.NodeType == ExpressionType.Convert)
			{
				var unaryExpr = lambda.Body as UnaryExpression;
				if (unaryExpr == null)
				{
					throw new ArgumentNullException("The converter expression has to be unary.");
				}

				memberExpr = unaryExpr.Operand as MemberExpression;
			}
			else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
			{
				memberExpr = lambda.Body as MemberExpression;
			}

			if (memberExpr == null)
				throw new ArgumentException("Not a member expression.");

			return memberExpr;
		}

		public static PropertyInfo GetPropertyInfo<T>(this Expression<Func<T, object>> expression)
		{
			var memberExpr = expression.GetMemberExpression();
			return (PropertyInfo) memberExpr.Member;
		}

		public static FieldInfo GetFieldInfo<T>(this Expression<Func<T, object>> expression)
		{
			var memberExpr = expression.GetMemberExpression();
			return (FieldInfo) memberExpr.Member;
		}
	}
}
