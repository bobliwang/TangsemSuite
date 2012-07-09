// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Tangsem.Generator.WebMvc3Demo.Controllers {
    public partial class CategoryController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CategoryController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult ListCategories() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.ListCategories);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CategoryController Actions { get { return MVC.Category; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Category";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Category";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string ListCategories = "ListCategories";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string ListCategories = "ListCategories";
        }


        static readonly ActionParamsClass_ListCategories s_params_ListCategories = new ActionParamsClass_ListCategories();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ListCategories ListCategoriesParams { get { return s_params_ListCategories; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ListCategories {
            public readonly string vm = "vm";
        }
        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string CatsGrid = "~/Views/Category/CatsGrid.cshtml";
            public readonly string ListCategories = "~/Views/Category/ListCategories.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_CategoryController: Tangsem.Generator.WebMvc3Demo.Controllers.CategoryController {
        public T4MVC_CategoryController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult ListCategories(Tangsem.Generator.WebMvc3Demo.ViewModels.CategoryViewModel vm) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.ListCategories);
            callInfo.RouteValueDictionary.Add("vm", vm);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
