using Microsoft.AspNetCore.Mvc;

namespace PVK_K65_NetCoreMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
