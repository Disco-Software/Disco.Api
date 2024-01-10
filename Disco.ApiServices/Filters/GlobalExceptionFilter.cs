using AutoMapper;
using Disco.Business.Exceptions;
using Disco.Business.Interfaces.Dtos.Errors.Admin.Error;
using Disco.Business.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
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
            else if (context.Exception is InvalidPasswordException)
            {
                var error = mapper.Map<ErrorDto>(context.Exception as InvalidPasswordException);

                context.Result = new JsonResult(error) { StatusCode = (int)HttpStatusCode.Unauthorized };
            }
            else if (context.Exception is InvalidRoleException)
            {
                var error = mapper.Map<ErrorDto>(context.Exception as InvalidPasswordException);

                context.Result = new JsonResult(error) { StatusCode = (int)HttpStatusCode.Unauthorized };
            }
            else if (context.Exception is PasswordRecoveryException)
            {
                var error = mapper.Map<ErrorDto>(context.Exception as PasswordRecoveryException);

                context.Result = new JsonResult(error) { StatusCode = (int)HttpStatusCode.Unauthorized };
            }

            return Task.CompletedTask;
        }
    }
}
