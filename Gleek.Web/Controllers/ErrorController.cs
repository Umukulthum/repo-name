using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gleek.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult CustomizeError(int statusCode)
        {
            if (statusCode == 404)
                return View("NotFound");
            else if (statusCode == 500)
                return View("ServerError");
            return View();
        }
    }
}