using System.Collections.Generic;

using ItemManagement_v2.Models;

namespace ItemManagement_v2.Repositories.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetItems();
        List<Item> SearchItem(string Name);
        List<Item> GetUserItems(string userId);

        Item GetItemById(long id);
        void CreateItem(Item item, string userId, string image64);
        void UpdateItem(Item item, string file);
        void DeleteItem(long id);

    }
}
