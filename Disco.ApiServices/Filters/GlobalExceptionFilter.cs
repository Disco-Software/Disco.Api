using AutoMapper;
using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Dtos.Errors;
using Disco.Business.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();

            if (context.Exception is ResourceNotFoundException)
            {
                var error = mapper.Map<ErrorDto>(context.Exception as ResourceNotFoundException);

                context.Result = new JsonResult(error) { StatusCode = (int)HttpStatusCode.NotFound };
            }
            else if (context.Exception is InvalidPostDataException)
            {
                var error = mapper.Map<ErrorDto>(context.Exception as InvalidPostDataException);

                context.Result = new JsonResult(error) { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            return Task.CompletedTask;
        }
    }
}
