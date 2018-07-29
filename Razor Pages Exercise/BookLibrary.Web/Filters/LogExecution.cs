namespace BookLibrary.Web.Filters
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    public class LogExecution : IActionFilter, IPageFilter
    {
        private ILogger<LogExecution> logger;
        private Stopwatch stopwatch;
        public LogExecution(ILogger<LogExecution> logger, Stopwatch stopwatch)
        {
            this.logger = logger;
            this.stopwatch = stopwatch;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this.LogEnteringMessage(context.HttpContext.Request.Method,
                context.Controller.GetType().Name.Replace("Controller", string.Empty),
                context.ActionDescriptor.RouteValues["action"],
                context.ModelState.IsValid);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.LogExitingMessage(context.HttpContext.Request.Method,
                context.Controller.GetType().Name.Replace("Controller", string.Empty),
                context.ActionDescriptor.RouteValues["action"]);
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            this.LogEnteringMessage(context.HttpContext.Request.Method,
                context.ActionDescriptor.DisplayName,
                context.HandlerMethod.Name,
                context.ModelState.IsValid);
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            this.LogExitingMessage(context.HttpContext.Request.Method,
                context.ActionDescriptor.DisplayName,
                context.HandlerMethod.Name);
        }

        private void LogEnteringMessage(string requestMethod,
            string controllerOrPage,
            string actionOrHandler,
            bool modelState)
        {
            var state = modelState ? "Valid" : "Invalid";

            this.logger.LogInformation($"info: Executing {requestMethod} {controllerOrPage}.{actionOrHandler}");
            this.logger.LogInformation($"info: Model state: {state}");

            this.stopwatch.Restart();
        }

        private void LogExitingMessage(string requestMethod,
            string controllerOrPage,
            string actionOrHandler)
        {
            this.stopwatch.Stop();

            this.logger.LogInformation($"info: Executed {requestMethod} {controllerOrPage}.{actionOrHandler} in {this.stopwatch.Elapsed.Seconds} s.");
        }
    }
}
