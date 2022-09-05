using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

using Ninject.Activation;
using Ninject.Planning.Targets;
using Ninject.Syntax;

using Tangsem.Common.Extensions;

namespace Tangsem.Generator.WebMvc3Demo.Extensions
{
  public static class BindingWithSyntaxExtensions
  {
    public static IBindingWithOrOnSyntax<T> WithPropertyValue<T>(this IBindingWithSyntax<T> binding, Expression<Func<T, object>> propertyExpression, Func<IContext, ITarget, object> callback)
    {
      var propertyInfo = propertyExpression.GetPropertyInfo();
      var propertyName = propertyInfo.Name;

      return binding.WithPropertyValue(propertyName, callback);
    }

    public static IBindingWithOrOnSyntax<T> WithPropertyValue<T>(this IBindingWithSyntax<T> binding, Expression<Func<T, object>> propertyExpression, Func<IContext, object> callback)
    {
      var propertyInfo = propertyExpression.GetPropertyInfo();
      var propertyName = propertyInfo.Name;

      return binding.WithPropertyValue(propertyName, callback);
    }

    public static IBindingWithOrOnSyntax<T> WithPropertyValue<T>(this IBindingWithSyntax<T> binding, Expression<Func<T, object>> propertyExpression, object value)
    {
      var propertyInfo = propertyExpression.GetPropertyInfo();
      var propertyName = propertyInfo.Name;

      return binding.WithPropertyValue(propertyName, value);
    }
  }
}