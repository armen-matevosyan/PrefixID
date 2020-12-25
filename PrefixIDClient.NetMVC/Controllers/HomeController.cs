using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrefixIDClient.NetMVC.Infrasructure;
using System.Threading.Tasks;

namespace PrefixIDClient.NetMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private IService _service;
      
        public HomeController(ILogger<HomeController> logger, IService service)
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
