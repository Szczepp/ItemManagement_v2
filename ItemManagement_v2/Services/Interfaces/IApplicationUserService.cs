using ItemManagement_v2.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ItemManagement_v2.ViewModels;

namespace ItemManagement_v2.Services.Interfaces
{
    public interface IApplicationUserService
    {
        List<ApplicationUser> GetApplicationUsers();
        ApplicationUser GetApplicationUserById(string id);
        void UpdateApplicationUser(ApplicationUserEdit user);
        void DeleteApplicationUser(string userId);
        void BlockApplicationUser(string userId);
        void UnblockApplicationUser(string userId);
        void AddApplicationUserToAdmin(string userId);
        void RemoveApplicationUserFromAdmin(string userId);
        IEnumerable<ApplicationUserWithRoles> GetApplicationUsersWithRoles();

    }
}
