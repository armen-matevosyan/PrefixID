using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Route("Widget")]
    public class WidgetController : Controller
    {
       
        public IActionResult Index([FromQuery] string key)
        {
            ViewBag.key = key;

            return View();
        }

    }
}

