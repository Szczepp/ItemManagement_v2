using ItemManagement_v2.Models;
using ItemManagement_v2.Repositories.Interfaces;
using ItemManagement_v2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.Language;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ItemManagement_v2.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly ICollectionRepository _collectionRepo;
        public CollectionService(ICollectionRepository collectionRepository)
        {
            _collectionRepo = collectionRepository;
        }

        public void CreateCollection(Collection collection, string userId, string FormItems, IFormFile file)
        {
            string image64 = this.ConvertImageToBase64(file);
            _collectionRepo.CreateCollection(collection, userId, FormItems, image64);
        }

        public void DeleteCollection(long id)
        {
            _collectionRepo.DeleteCollection(id);
        }

        public Collection GetCollectionById(long id)
        {
            return _collectionRepo.GetCollectionById(id);
        }

        public List<Collection> GetCollections()
        {
            return _collectionRepo.GetCollections();
        }

        public List<Item> GetItemsFromCollection(Collection collection)
        {
            return _collectionRepo.GetItemsFromCollection(collection);
        }

        public List<Item> GetItemsNotFromCollection(Collection collection)
        {
            return _collectionRepo.GetItemsNotFromCollection(collection);
        }

        public List<Collection> SearchCollection(string Name)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCollection(Collection collection, string FormItems, IFormFile file)
        {
            string image64 = this.ConvertImageToBase64(file);

            _collectionRepo.UpdateCollection(collection, FormItems, image64);
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

        public List<Collection> GetUserCollections(string userId)
        {
            return _collectionRepo.GetUserCollections(userId);
        }
    }
}
