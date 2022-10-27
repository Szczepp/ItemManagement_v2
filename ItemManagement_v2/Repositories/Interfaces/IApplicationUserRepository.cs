using ItemManagement_v2.Models;
using ItemManagement_v2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManagement_v2.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetApplicationUsers();
        ApplicationUser GetApplicationUserById(string id);
        void UpdateApplicationUser(ApplicationUserEdit user);
        void DeleteApplicationUser(string userId);
        void BlockApplicationUser(string userId);
        void UnblockApplicationUser(string userId);
        Task<IActionResult> AddApplicationUserToAdmin(string userId);
        Task<IActionResult> RemoveApplicationUserFromAdmin(string userId);
        IEnumerable<ApplicationUserWithRoles> GetApplicationUsersWithRoles();
    }
}
