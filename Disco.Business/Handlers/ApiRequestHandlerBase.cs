using Microsoft.AspNetCore.Mvc;

namespace Disco.Business.Handlers
{
    public abstract class ApiRequestHandlerBase
    {
        public static OkObjectResult Ok(object value) => new OkObjectResult(value);
        public static OkResult Ok() => new OkResult();
        public static BadRequestResult BadRequest() => new BadRequestResult();
        public static BadRequestObjectResult BadRequest(object value) => new BadRequestObjectResult(value);

    }
}
