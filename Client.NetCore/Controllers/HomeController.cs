using Client.NetCore.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Client.NetCore.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private IServiceLogic _service;
      
        public HomeController(ILogger<HomeController> logger, IServiceLogic service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var authorizationResponse = await _service.GetRequestID();
            var widgetResponse = await _service.GetWidget(authorizationResponse.request_id, "ARM", "I");

            ViewBag.Key = widgetResponse.key;

            return View();
        }

        
       

    }
}
