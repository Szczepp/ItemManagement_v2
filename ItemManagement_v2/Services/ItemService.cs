using ItemManagement_v2.Models;
using ItemManagement_v2.Repositories;
using ItemManagement_v2.Repositories.Interfaces;
using ItemManagement_v2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace ItemManagement_v2.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepo;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepo = itemRepository;
        }

        public void CreateItem(Item item, string userId, IFormFile file)
        {

            string image64 = this.ConvertImageToBase64(file)?? "";
            
            _itemRepo.CreateItem(item, userId, image64);
        }

        public void DeleteItem(long id)
        {
            _itemRepo.DeleteItem(id);
        }

        public Item GetItemById(long id)
        {
            return _itemRepo.GetItemById(id);
        }

        public List<Item> GetItems()
        {
            return _itemRepo.GetItems();
        }

        public List<Item> SearchItem(string Name)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateItem(Item item, IFormFile file)
        {
            string image64 = "";
            if (file != null)
            {
                image64 = this.ConvertImageToBase64(file);
            }

            _itemRepo.UpdateItem(item, image64);
        }

        public string ConvertImageToBase64(IFormFile file)
        {
            if (file == null)
            {
                return "";
            }
            var imgBytes = new Byte[file.Length - 1];
            var dataStream = new MemoryStream();
            file.CopyToAsync(dataStream);
            byte[] imageBytes = dataStream.ToArray();

            return Convert.ToBase64String(imageBytes);
        }
    }
}
