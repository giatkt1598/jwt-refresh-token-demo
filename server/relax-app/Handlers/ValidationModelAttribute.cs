using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using relax_app.Extentions;
using relax_app.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relax_app.Handlers
{
    public class ValidationModelAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorResponse = new ErrorResponse
                {
                    Status = StatusCodes.Status404NotFound,
                    Errors = new List<ErrorField>(),
                    Title = "One or more fields had errors"
                };
                foreach (var err in context.ModelState.Where(x => x.Value.Errors.Count > 0))
                {

                    errorResponse.Errors.Add(new ErrorField
                    {
                        Field = err.Key.ToSnakeCase(),
                        Messages = err.Value.Errors.Select(x => x.ErrorMessage).ToList(),
                    });
                }
                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
        }
    }
}
