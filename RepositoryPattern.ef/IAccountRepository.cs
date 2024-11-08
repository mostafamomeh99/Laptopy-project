using Microsoft.AspNetCore.Identity;
using Repositorypattern.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.ef
{
   public interface IAccountRepository
    {
         Task<ApplicationUser> FindUserByNameAsync(string userId);
        Task<ApplicationUser> FindUserByEmailAsync(string userId);
        Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password);
        Task SignineAsync(ApplicationUser user);
            Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task SignOutAsync();

    }
}
