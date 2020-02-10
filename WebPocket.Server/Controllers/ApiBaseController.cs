﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using WebPocket.Common.RequestResult;

namespace WebPocket.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class ApiBaseController : Controller
    {
        protected string UserId 
        { 
            get 
            { 
                return HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); 
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if ((context.Result as ObjectResult)?.Value is RequestResult requestResult)
            {
                context.HttpContext.Response.StatusCode = requestResult.StatusCode;
            }
        }
    }
}
