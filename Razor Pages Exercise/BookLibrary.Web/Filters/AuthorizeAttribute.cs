namespace BookLibrary.Web.Filters
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using static Constants;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IActionFilter, IPageFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;

            if (session.GetString(CurrentUserSessionKey) == null)
            {
                context.Result = new RedirectResult("/Users/Login");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var session = context.HttpContext.Session;

            if (session.GetString(CurrentUserSessionKey) == null)
            {
                context.Result = context.Result = new RedirectResult("/Users/Login");
            }
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }
    }
}
