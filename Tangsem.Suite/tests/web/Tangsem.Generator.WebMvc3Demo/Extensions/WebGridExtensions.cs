﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.WebPages;
using Tangsem.Common.Extensions.Linq;
namespace Tangsem.Generator.WebMvc3Demo.Extensions
{
  public static class WebGridExtensions
  {
    public static void Bind<T>(this WebGrid webGrid, WebPageBase webPage, IQueryable<T> dataSource) where T : class
    {
      int page;
      int.TryParse(webPage.Request[webGrid.PageFieldName], out page);
      page = (page > 0 ? page : 1) - 1;

      var rowsCount = dataSource.Count();
      var qry = dataSource;

      // do sort here..
      var sortBy = webPage.Request[webGrid.SortFieldName];
      var sortDir = webPage.Request[webGrid.SortDirectionFieldName];
      var sortExpression = sortBy + " " + sortDir;

      if (!string.IsNullOrWhiteSpace(sortExpression))
      {
        qry = qry.OrderBy(sortExpression);
      }
      qry = qry.Skip(page * webGrid.RowsPerPage).Take(webGrid.RowsPerPage);
      webGrid.Bind(qry.ToList(), autoSortAndPage: false, rowCount: rowsCount);
    }
  }
}