using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NLog.Web;
using relax_app.Models.Responses;

namespace WebApi.Handlers
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is System.Linq.Dynamic.Core.Exceptions.ParseException)
            {
                context.Result = new ObjectResult(new ErrorResponse(context.Exception.Message, 
                    (int)HttpStatusCode.BadRequest))
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
                context.ExceptionHandled = true;
                return;
            }
            if (context.Exception is UnauthorizedAccessException)
            {
                context.Result = new ForbidResult();
                context.ExceptionHandled = true;
                return;
            }
            if (context.Exception is Microsoft.EntityFrameworkCore.DbUpdateException)
            {
#if DEBUG
                string errorMessage = context.Exception?.InnerException?.ToString() ?? context.Exception.Message;
                context.Result = new ObjectResult(new ErrorResponse(errorMessage, StatusCodes.Status400BadRequest))
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
#else
                context.Result = new ObjectResult(new ErrorResponse(context.Exception.Message, StatusCodes.Status400BadRequest))
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
#endif
                context.ExceptionHandled = true;
                return;
            }
#if DEBUG
            context.Result = new ObjectResult(new ErrorResponse(context.Exception.ToString(), 
                (int)HttpStatusCode.InternalServerError))
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
            };
            context.ExceptionHandled = true;
#else
            context.Result = new ObjectResult(new ErrorResponse("Opps, something went wrong!", (int)HttpStatusCode.InternalServerError))
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
            };
            context.ExceptionHandled = true;
#endif
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            logger.Error(context.Exception.ToString());
        }
    }
}
