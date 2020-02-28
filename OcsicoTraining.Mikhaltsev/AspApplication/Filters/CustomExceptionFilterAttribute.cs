using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Filters
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionModel = new CustomErrorViewModel
            {
                ActionName = context.ActionDescriptor.DisplayName,
                Stack = context.Exception.StackTrace,
                Message = context.Exception.Message,
                InnerException = context.Exception.InnerException
            };
            var result = new ViewResult { ViewName = "CustomError" };
            var modelMetadata = new EmptyModelMetadataProvider();

            result.ViewData = new ViewDataDictionary<CustomErrorViewModel>(modelMetadata, context.ModelState)
            {
                { "CustomException", exceptionModel }
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
