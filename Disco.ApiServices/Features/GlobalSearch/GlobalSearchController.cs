using AutoMapper;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Search;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Disco.ApiServices.Controllers;
using MediatR;
using Disco.ApiServices.Features.GlobalSearch.RequestHandlers.Search;

namespace Disco.ApiServices.Features.GlobalSearch
{
    [Route("api/user/global/search")]
    public class GlobalSearchController : UserController
    {
        private readonly IMediator _mediator;
        
        public GlobalSearchController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GlobalSearchResponseDto>> Serach([FromQuery] string search) =>
            await _mediator.Send(new SearchRequest(search));
    }
}
