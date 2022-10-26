using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ItemManagement_v2.Models;
using ItemManagement_v2.Services.Interfaces;
using ItemManagement_v2.Filters;

namespace ItemManagement_v2.Areas.Admin.Controllers
{
    [AdminAuthorizationFilter]
    [Area("Admin")]

    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserService _appUserService;
        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _appUserService = applicationUserService;
        }

        public IActionResult Index()
        {
            List<ApplicationUser> users = _appUserService.GetApplicationUsers();
            return View(users);
        }

        public IActionResult Details(string id)
        {
            ApplicationUser user = _appUserService.GetApplicationUserById(id);
            return View(user);
        }

        public IActionResult Block(string id)
        {
            _appUserService.BlockApplicationUser(id);
            return RedirectToAction("Index");
        }

        public IActionResult Unblock(string id)
        {
            _appUserService.UnblockApplicationUser(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            var user = _appUserService.GetApplicationUserById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationUser user)
        {
            _appUserService.UpdateApplicationUser(user);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            _appUserService.DeleteApplicationUser(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddToAdmin(string id)
        {
            _appUserService.AddApplicationUserToAdmin(id);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromAdmin(string id)
        {
            _appUserService.RemoveApplicationUserFromAdmin(id);
            return RedirectToAction("Index");
        }
    }
}
