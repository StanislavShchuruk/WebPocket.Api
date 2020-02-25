using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;
using WebPocket.Services.RequestResults;

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

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if ((context.Result as ObjectResult)?.Value is RequestResult requestResult)
            {
                context.HttpContext.Response.StatusCode = requestResult.StatusCode;
            }
        }

        protected RequestResult GetModelStateErrorsRequestResult()
        {
            var errorMessages = ModelState.Where(kvp => kvp.Value.Errors.Count > 0)
                .SelectMany(kvp => kvp.Value.Errors.Select(err => err.ErrorMessage))
                .ToArray();
            return new RequestResult
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Errors = errorMessages
            };
        }
    }
}
