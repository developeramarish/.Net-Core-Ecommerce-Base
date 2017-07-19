using Microsoft.AspNetCore.Mvc;

namespace Shop.Features.Admin
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}