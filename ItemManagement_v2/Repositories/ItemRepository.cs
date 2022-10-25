using ItemManagement_v2.Contexts;
using ItemManagement_v2.Models;
using ItemManagement_v2.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ItemManagement_v2.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _db;
        public ItemRepository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public void CreateItem(Item item, string userId, string file)
        {
            var user = _db.Users.Find(userId);
            item.ApplicationUser = user;
            item.Image = file;
            _db.Items.Add(item);
            _db.SaveChanges();
        }

        public void DeleteItem(long id)
        {
            var item = this.GetItemById(id);
            _db.Items.Remove(item);
            _db.SaveChanges();

        }

        public Item GetItemById(long id)
        {
            return _db.Items.Include(i => i.ApplicationUser).Where(i => i.Id == id).FirstOrDefault();
        }

        public List<Item> GetItems()
        {
            return _db.Items.ToList();
        }

        public List<Item> SearchItem(string Name)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateItem(Item item, string image64)
        {
            Item existingItem = this.GetItemById(item.Id);
            if(image64 == "")
            {
                item.Image = existingItem.Image;
            }else
            {
                item.Image = image64;
            }
            item.ApplicationUser = existingItem.ApplicationUser;
            _db.Entry(existingItem).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
