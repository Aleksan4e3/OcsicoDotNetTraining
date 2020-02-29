using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Filters
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilterAttribute> logger;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogInformation(context.Exception.Message);

            context.Result = new ViewResult { ViewName = "CustomError" };
            context.ExceptionHandled = true;
        }
    }
}
