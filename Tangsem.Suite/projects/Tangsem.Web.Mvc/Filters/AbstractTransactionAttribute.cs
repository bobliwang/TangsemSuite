using System;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

using Tangsem.Data.Domain;

namespace Tangsem.Web.Mvc
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
  public class AbstractTransactionAttribute : ActionFilterAttribute, IPageFilter
  {
    public IsolationLevel IsolationLevel { get; set; } = IsolationLevel.ReadCommitted;

    public Type RepositoryType { get; set; }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
      this.OpenTransaction(context.HttpContext);
      base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
      base.OnActionExecuted(context);
      this.CompleteTransaction(context.HttpContext, context.Exception);
    }

    private void OpenTransaction(HttpContext httpContext)
    {
      var repo = this.GetRepository(httpContext);
      Trace.TraceInformation(">>>>>>>>> STARTING TRANSACTION <<<<<<<<<");
      repo.BeginTransaction(this.IsolationLevel);
    }

    private void CompleteTransaction(HttpContext httpContext, Exception ex)
    {
      using (var repo = this.GetRepository(httpContext))
      {
        if (repo.IsInTransaction)
        {
          if (ex == null)
          {
            Trace.TraceInformation(">>>>>>>>> COMMITTING <<<<<<<<<");
            repo.Commit();
          }
          else
          {
            Trace.TraceInformation(">>>>>>>>> ROLLBACK <<<<<<<<<");
            repo.Rollback();
          }
        }
      }
    }

    private IRepository GetRepository(HttpContext httpContext)
    {
      return httpContext.RequestServices.GetService(this.RepositoryType) as IRepository;
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
      this.OpenTransaction(context.HttpContext);
    }

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
      this.CompleteTransaction(context.HttpContext, context.Exception);
    }
  }
}