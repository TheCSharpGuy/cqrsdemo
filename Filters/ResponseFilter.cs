using CQRSDemo.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CQRSDemo.Filters
{
    public class ResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value is BaseResponse response && response.StatusCode != HttpStatusCode.OK)
                context.Result = new ObjectResult(new { response.ErrorMessage }) { StatusCode = (int)response.StatusCode };
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
