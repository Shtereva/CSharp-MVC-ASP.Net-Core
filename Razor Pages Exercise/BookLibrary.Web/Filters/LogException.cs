namespace BookLibrary.Web.Filters
{
    using System;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;

    public class LogException : IExceptionFilter
    {
        private ILogger<LogException> logger;

        public LogException(ILogger<LogException> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var type = context.Exception.GetType().Name;
            var stackTrace = context.Exception.StackTrace;

            this.logger.LogError($"error: Type {type}{Environment.NewLine}{stackTrace}");
        }
    }
}
