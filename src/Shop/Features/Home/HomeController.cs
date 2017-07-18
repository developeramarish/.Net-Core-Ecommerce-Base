using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Features.Home
{
    public class HomeController : Controller
    {
        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }

    }
}