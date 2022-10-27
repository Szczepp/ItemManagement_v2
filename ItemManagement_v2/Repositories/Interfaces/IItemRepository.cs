using System.Collections.Generic;

using ItemManagement_v2.Models;

namespace ItemManagement_v2.Repositories.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetItems();
        List<Item> SearchItem(string Name);
        Item GetItemById(long id);
        void CreateItem(Item item, string userId, string file);
        void UpdateItem(Item item, string file);
        void DeleteItem(long id);

    }
}
