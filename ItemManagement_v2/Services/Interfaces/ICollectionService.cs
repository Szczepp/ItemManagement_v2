using ItemManagement_v2.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ItemManagement_v2.Services.Interfaces
{
    public interface ICollectionService
    {
        List<Collection> GetCollections();
        List<Collection> SearchCollection(string Name);
        List<Collection> GetUserCollections(string userId);
        Collection GetCollectionById(long id);
        void CreateCollection(Collection collection, string userId, string FormItems, IFormFile file);
        void UpdateCollection(Collection collection, string FormItems, IFormFile file);
        List<Item> GetItemsFromCollection(Collection collection);
        List<Item> GetItemsNotFromCollection(Collection collection);
        void DeleteCollection(long id);
    }
}
