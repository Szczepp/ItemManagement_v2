using Microsoft.AspNetCore.Mvc;
using ItemManagement_v2.Filters;

namespace ItemManagement_v2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizationFilter]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
