using Microsoft.AspNetCore.Mvc;

namespace PVK_K65_NetCoreMVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
