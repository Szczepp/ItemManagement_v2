using ItemManagement_v2.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace ItemManagement_v2.Services.Interfaces
{
    public interface IIdentityUserService
    {
        List<IdentityUser> GetIdentityUsers();
        IdentityUser GetIdentityUserById(string id);
        void UpdateIdentityUser(IdentityUser user);
        void DeleteIdentityUser(long id);
    }
}
