using ItemManagement_v2.Models;
using ItemManagement_v2.Services.Interfaces;
using ItemManagement_v2.Repositories.Interfaces;
using System.Collections.Generic;
using ItemManagement_v2.ViewModels;

namespace ItemManagement_v2.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _appUserRepo;
        public ApplicationUserService(IApplicationUserRepository applicationUserRepository)
        {
            _appUserRepo = applicationUserRepository;
        }

        public void BlockApplicationUser(string userId)
        {
            _appUserRepo.BlockApplicationUser(userId);
        }

        public void DeleteApplicationUser(string userId)
        {
            _appUserRepo.DeleteApplicationUser(userId);
        }

        public ApplicationUser GetApplicationUserById(string userId)
        {
            return _appUserRepo.GetApplicationUserById(userId);
        }

        public List<ApplicationUser> GetApplicationUsers()
        {
            
            return _appUserRepo.GetApplicationUsers();
        }
        public void AddApplicationUserToAdmin(string userId)
        {
            _appUserRepo.AddApplicationUserToAdmin(userId);
        }
        public void RemoveApplicationUserFromAdmin(string userId)
        {
            _appUserRepo.RemoveApplicationUserFromAdmin(userId);
        }

        public void UnblockApplicationUser(string userId)
        {
            _appUserRepo.UnblockApplicationUser(userId);
        }

        public void UpdateApplicationUser(ApplicationUserEdit user)
        {
            _appUserRepo.UpdateApplicationUser(user);
        }

        public IEnumerable<ApplicationUserWithRoles> GetApplicationUsersWithRoles()
        {
            return _appUserRepo.GetApplicationUsersWithRoles();
        }
    }
}
