using ItemManagement_v2.Contexts;
using ItemManagement_v2.Models;
using ItemManagement_v2.ViewModels;
using ItemManagement_v2.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

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
            var result =  _userManager.AddToRoleAsync(user, "Admin").Result;
            return null;
        }

        public Task<IActionResult> RemoveApplicationUserFromAdmin(string userId)
        {
            var user = this.GetApplicationUserById(userId);
            var result = _userManager.RemoveFromRoleAsync(user, "Admin").Result;
            return null;
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

        public void UpdateApplicationUser(ApplicationUserEdit user)
        {
            var existingUser = this.GetApplicationUserById(user.Id);
            existingUser.UserName = user.UserName;
            existingUser.Email= user.Email;
            _db.Users.Update(existingUser);
            _db.SaveChanges();
        }

        public IEnumerable<ApplicationUserWithRoles> GetApplicationUsersWithRoles()
        {
            return (from u in _db.Users
                    join ur in _db.UserRoles on u.Id equals ur.UserId
                    
                    select new ApplicationUserWithRoles
                    {
                        Id = u.Id,
                        Email = u.Email,
                        Username = u.UserName,
                        IsActive = u.IsActive,
                        RoleId = ur.RoleId,
                    }
                    ).AsEnumerable();
        }
    }
}
