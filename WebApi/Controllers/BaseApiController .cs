using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController  : ControllerBase
    {
        private IMediator _mediatr;

        protected IMediator Mediator => _mediatr ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(BaseCommandResponse<T> result)
        {
            if (result == null)
                return NotFound(new BaseCommandResponse<int> { Success = false, Message = "Data not found" });

            if (result.Success && result.Value != null)
                return Ok(result);
            if (result.Success && result.Value == null)
                return NotFound(result);


            return BadRequest(result);
        }
    }
}