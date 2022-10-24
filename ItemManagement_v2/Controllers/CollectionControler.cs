using ItemManagement_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using System.Collections.Generic;

namespace ItemManagement_v2.Controllers
{
    public class CollectionControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /*public ActionResult Create()
        {
            List<Item> Items = _itemService.GetItems();

            return View(Items);
        }

        [HttpPost]
        public ActionResult Create(ItemCollection collection)
        {
            _itemCollectionService.CreateItemCollection(collection, Request.Form["Items"]);

            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            ItemCollection itemCollection = _itemCollectionService.GetItemCollectionById(id);
            ViewBag.Items = _itemCollectionService.GetItemsFromItemCollection(itemCollection);

            return View(itemCollection);
        }
        public ActionResult Edit(long id)
        {
            ItemCollection itemCollection = _itemCollectionService.GetItemCollectionById(id);
            ViewBag.ItemsInCollection = _itemCollectionService.GetItemsFromItemCollection(itemCollection);
            ViewBag.ItemsNotInCollection = _itemCollectionService.GetItemsNotFromItemCollection(itemCollection);

            return View(itemCollection);
        }

        [HttpPost]
        public ActionResult Edit(ItemCollection collection)
        {
            _itemCollectionService.UpdateItemCollection(collection, Request.Form["Items"]);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            _itemCollectionService.DeleteItemCollection(id);

            return RedirectToAction("Index");
        }*/
    }
}
