using ItemManagement_v2.Services;
using ItemManagement_v2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using System.IO;
using ItemManagement_v2.Services.Interfaces;

namespace ItemManagement_v2.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ItemController(IItemService itemService, IHttpContextAccessor httpContextAccessor)
        {
            _itemService = itemService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            List <Item> items = _itemService.GetItems();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var user = _httpContextAccessor.HttpContext.User.Identity;
            var file = Request.Form.Files[0];
            _itemService.CreateItem(item, userId, file);
            return RedirectToAction("Index");
        }

        public IActionResult Details(long id)
        {
            var item = _itemService.GetItemById(id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        public IActionResult Edit(long id)
        {
            Item item = _itemService.GetItemById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            IFormFile file;
            try
            {
                 file = Request.Form.Files[0];
            }catch(ArgumentOutOfRangeException e)
            {
                file = null;
            }

            _itemService.UpdateItem(item, file);
            return RedirectToAction("Index");
        }
    }
}
