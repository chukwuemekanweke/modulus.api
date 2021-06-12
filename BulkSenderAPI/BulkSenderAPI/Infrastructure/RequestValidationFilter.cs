using BulkSenderAPI.Model.Enums;
using BulkSenderAPI.Model.Utils;
using dijitalu.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijitalu.WebApi.Infrastructure
{
  
    public class RequestValidationFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var modelState = context.ModelState;

            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(v => v.Errors).Select(m => m.ErrorMessage).ToList();
                var stringBuilder = new StringBuilder();
                errors.ForEach(m => stringBuilder.AppendLine(m));

                string validationError = stringBuilder.ToString();

                ErrorDetails errorDetails = new ErrorDetails
                {
                    Status = ResponseStatus.FatalError,
                    Data = validationError,
                    Message = "Request Model Validation Errors"
                };

                context.Result = new BadRequestObjectResult(errorDetails);

                
                return base.OnActionExecutionAsync(context, next);
            }

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
