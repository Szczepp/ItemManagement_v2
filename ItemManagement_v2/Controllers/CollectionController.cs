using ItemManagement_v2.Filters;
using ItemManagement_v2.Models;
using ItemManagement_v2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ItemManagement_v2.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionService _collectionService;
        private readonly IItemService _itemService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CollectionController(ICollectionService collectionService, IItemService itemService, IHttpContextAccessor httpContextAccessor)
        {
            _collectionService = collectionService;
            _httpContextAccessor = httpContextAccessor;
            _itemService = itemService;
        }
        public IActionResult Index()
        {
            List<Collection> collections = _collectionService.GetCollections();
            return View(collections);
        }

        [AuthenticationFilter]
        public ActionResult Create()
        {
            ViewBag.AvailableTopics = new List<String> { "Spring", "Summer", "Fall", "Winter" };  
            List<Item> Items = _itemService.GetItems();

            return View(Items);
        }

        [AuthenticationFilter]
        [HttpPost]
        public ActionResult Create(Collection collection)
        {
            
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var file = Request.Form.Files[0];
            _collectionService.CreateCollection(collection, userId, Request.Form["Items"], file);

            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            Collection itemCollection = _collectionService.GetCollectionById(id);
            ViewBag.Items = _collectionService.GetItemsFromCollection(itemCollection);

            return View(itemCollection);
        }

        [AuthenticationFilter]
        public ActionResult Edit(long id)
        {
            Collection itemCollection = _collectionService.GetCollectionById(id);
            ViewBag.ItemsInCollection = _collectionService.GetItemsFromCollection(itemCollection);
            ViewBag.ItemsNotInCollection = _collectionService.GetItemsNotFromCollection(itemCollection);

            return View(itemCollection);
        }

        [AuthenticationFilter]
        [HttpPost]
        public ActionResult Edit(Collection collection)
        {
            IFormFile file;
            try
            {
                file = Request.Form.Files[0];
            }
            catch (ArgumentOutOfRangeException e)
            {
                file = null;
            }
            _collectionService.UpdateCollection(collection, Request.Form["Items"], file);

            return RedirectToAction("Index");
        }

        [AuthenticationFilter]
        public ActionResult Delete(long id)
        {
            _collectionService.DeleteCollection(id);

            return RedirectToAction("Index");
        }
    }
}
