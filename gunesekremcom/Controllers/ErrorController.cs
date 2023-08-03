using gunesekremcom.Tools.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace gunesekremcom.Controllers.ErrorController
{
    public class ErrorController : Controller
    {
        [Route("/Error/Error")]
        public IActionResult Error(int code)
        {
            TempData["code"] = code;
            if (code == 404)
            {
                return View();
            }
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            LogHelper.Log(null, errorInfo, code);

            return View();
        }

    }
}
