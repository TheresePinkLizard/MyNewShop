using Microsoft.AspNetCore.Mvc;

namespace MyNewShop.Controllers 
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}