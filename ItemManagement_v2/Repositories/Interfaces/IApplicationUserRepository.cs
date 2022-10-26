using ItemManagement_v2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManagement_v2.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetApplicationUsers();
        ApplicationUser GetApplicationUserById(string id);
        void UpdateApplicationUser(ApplicationUser user);
        void DeleteApplicationUser(string userId);
        void BlockApplicationUser(string userId);
        void UnblockApplicationUser(string userId);
        Task<IActionResult> AddApplicationUserToAdmin(string userId);
        void RemoveApplicationUserFromAdmin(string userId);
    }
}
