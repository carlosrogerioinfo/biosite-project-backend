using Biosite.Core.Response;
using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biosite.Core.Controller
{
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController() { }

        protected new async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    return await Task.FromResult(Ok(BaseResponse.Create(result, true)));
                }
                catch (Exception e)
                {
                    return await Task.FromResult(Ok(BaseErrorResponse.Create(e.Message)));
                }
            }
            else
            {
                return await Task.FromResult(BadRequest(BaseErrorResponse.Create(notifications)));
            }
        }
    }
}
