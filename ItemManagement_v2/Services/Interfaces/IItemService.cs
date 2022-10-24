using ItemManagement_v2.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;


namespace ItemManagement_v2.Services.Interfaces
{
    public interface IItemService
    {
        List<Item> GetItems();
        List<Item> SearchItem(string Name);
        Item GetItemById(long id);
        void CreateItem(Item item, string userId, IFormFile file);
        void UpdateItem(Item item, IFormFile file);
        void DeleteItem(long id);
    }
}
