using ItemManagement_v2.Contexts;
using ItemManagement_v2.Models;
using ItemManagement_v2.Repositories.Interfaces;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ItemManagement_v2.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly ApplicationDbContext _db;
        public CollectionRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public void CreateCollection(Collection collection, string userId, string FormItems, string image64)
        {
            List<Item> ItemsList = new List<Item>();
            if (FormItems != null)
            {
                var itemsIdArray = FormItems.Split(',');
                foreach (var id in itemsIdArray)
                {
                    long itemId = long.Parse(id);
                    ItemsList.Add(_db.Items.Where(temp => temp.Id == itemId).FirstOrDefault());
                }
            }
            var author = _db.Users.Find(userId);
            collection.IdentityUser = author;
            collection.Image = image64;
            collection.Items = ItemsList;
            _db.Collections.Add(collection);
            _db.SaveChanges();
        }

        public void DeleteCollection(long id)
        {
            Collection collection = _db.Collections.Find(id);
            _db.Collections.Remove(collection);
            _db.SaveChanges();
        }

        public Collection GetCollectionById(long id)
        {
            return _db.Collections.Where(temp => temp.Id == id)
                .Include(c => c.Items)
                .Include(c => c.IdentityUser)
                .FirstOrDefault();
        }

        public List<Collection> GetCollections()
        {
            return _db.Collections.ToList();
        }

        public List<Item> GetItemsFromCollection(Collection collection)
        {
            return collection.Items.ToList();
        }

        public List<Item> GetItemsNotFromCollection(Collection collection)
        {
            var ItemsInCollectionIds = collection.Items.Select(temp => temp.Id).ToArray();
            return _db.Items.Where(temp => !ItemsInCollectionIds.Contains(temp.Id)).ToList();
        }

        public List<Collection> SearchCollection(string Name)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCollection(Collection collection, string FormItems, string image64)
        {
            Collection existingItemCollection = this.GetCollectionById(collection.Id);
            var existingCollectionItems = this.GetItemsFromCollection(existingItemCollection);
            foreach (var item in existingCollectionItems)
            {
                var id = item.Id;
                existingItemCollection.Items.Remove(item);
            }
            if (FormItems != null)
            {
                var itemsIdArray = FormItems.Split(',');
                foreach (var itemId in itemsIdArray)
                {
                    long longItemId = long.Parse(itemId);
                    existingItemCollection.Items.Add(_db.Items.Where(temp => temp.Id == longItemId).FirstOrDefault());
                }
            }
            collection.Image = image64;
            _db.Entry(existingItemCollection).CurrentValues.SetValues(collection);
            _db.SaveChanges();
        }
    }
}
