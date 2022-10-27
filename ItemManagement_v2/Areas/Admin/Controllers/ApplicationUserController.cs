using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ItemManagement_v2.Models;
using ItemManagement_v2.ViewModels;
using ItemManagement_v2.Services.Interfaces;
using ItemManagement_v2.Filters;

namespace ItemManagement_v2.Areas.Admin.Controllers
{
    [AdminAuthorizationFilter]
    [Area("Admin")]

    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserService _appUserService;
        private readonly IItemService _itemService;
        private readonly ICollectionService _collectionService;
        public ApplicationUserController(IApplicationUserService applicationUserService, IItemService itemService, ICollectionService collectionService)
        {
            _appUserService = applicationUserService;
            _itemService = itemService;
            _collectionService = collectionService; 
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationUserWithRoles> usersWithRoles = _appUserService.GetApplicationUsersWithRoles();
            List<ApplicationUser> users = _appUserService.GetApplicationUsers();
            return View(usersWithRoles);
        }

        public IActionResult Details(string id)
        {
            ViewBag.UserItems = _itemService.GetUserItems(id);
            ViewBag.UserCollections = _collectionService.GetUserCollections(id);
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
            var userEditViewModel = new ApplicationUserEdit
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
            return View(userEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationUserEdit user)
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
