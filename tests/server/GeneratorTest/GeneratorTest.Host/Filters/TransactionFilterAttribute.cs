using System;
using GeneratorTest.Common.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace GeneratorTest.Host.Filters
{
  [AttributeUsage(AttributeTargets.Method)]
  public class TransactionFilterAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      var repo = this.GetRepository(context.HttpContext);

      repo.BeginTransaction();
      base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
      base.OnActionExecuted(context);

      using (var repo = this.GetRepository(context.HttpContext))
      {
        if (repo.IsInTransaction)
        {
          if (context.Exception == null)
          {
            repo.Commit();
          }
          else
          {
            repo.Rollback();
          }
        }
      }
    }

    private IGeneratorTestRepository GetRepository(HttpContext httpContext)
    {
      return httpContext.RequestServices.GetService<IGeneratorTestRepository>();
    }
  }
}