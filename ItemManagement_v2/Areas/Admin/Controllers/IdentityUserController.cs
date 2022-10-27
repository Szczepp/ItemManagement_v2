using Microsoft.AspNetCore.Mvc;

namespace ItemManagement_v2.Areas.Admin.Controllers
{
    public class IdentityUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
