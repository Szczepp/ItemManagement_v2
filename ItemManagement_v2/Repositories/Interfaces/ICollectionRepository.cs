using ItemManagement_v2.Models;
using System.Collections.Generic;

namespace ItemManagement_v2.Repositories.Interfaces
{
    public interface ICollectionRepository
    {
        List<Collection> GetCollections();
        List<Collection> SearchCollection(string Name);
        List<Collection> GetUserCollections(string userId);

        Collection GetCollectionById(long id);
        void CreateCollection(Collection collection, string userId, string FormItems, string image64);
        void UpdateCollection(Collection collection, string FormItems, string image64);
        List<Item> GetItemsFromCollection(Collection collection);
        List<Item> GetItemsNotFromCollection(Collection collection);
        void DeleteCollection(long id);
    }
}
