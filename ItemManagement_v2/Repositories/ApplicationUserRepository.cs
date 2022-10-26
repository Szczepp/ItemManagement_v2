using ItemManagement_v2.Contexts;
using ItemManagement_v2.Models;
using ItemManagement_v2.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement_v2.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserRepository(ApplicationDbContext applicationDbcontext, UserManager<ApplicationUser> userManager)
        {
            _db = applicationDbcontext;
            _userManager = userManager;
        }

        public void DeleteApplicationUser(string userId)
        {
            var user = this.GetApplicationUserById(userId);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public ApplicationUser GetApplicationUserById(string userId)
        {
            return _db.Users.Find(userId);
        }

        public List<ApplicationUser> GetApplicationUsers()
        {
            return _db.Users.ToList();
        }
        public async Task<IActionResult> AddApplicationUserToAdmin(string userId)
        {
            var user = this.GetApplicationUserById(userId);
            await _userManager.AddToRoleAsync(user, "Admin");
            return null;
        }

        public void RemoveApplicationUserFromAdmin(string userId)
        {
            var user = this.GetApplicationUserById(userId);
            _userManager.RemoveFromRoleAsync(user, "Admin");
        }

        public void BlockApplicationUser(string userId)
        {
            var user = this.GetApplicationUserById(userId);
            user.IsActive = false;
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void UnblockApplicationUser(string userId)
        {
            var user = this.GetApplicationUserById(userId);
            user.IsActive = true;
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void UpdateApplicationUser(ApplicationUser user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }
    }
}
