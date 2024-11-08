using Microsoft.AspNetCore.Identity;
using Repositorypattern.core.IDatabaseRepository;
using Repositorypattern.core.Models;
using Repositorypattern.ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.ef.Repositories
{
    public class AccountRespository : IAccountRepository
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signinManager;
        public AccountRespository(UserManager<ApplicationUser> userManager 
            , SignInManager<ApplicationUser> signinManager) {

            this.userManager = userManager;
            this.signinManager = signinManager;
        }


        public async Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> FindUserByNameAsync(string userId)
        {
            return await userManager.FindByNameAsync(userId);
        }
        public async Task<ApplicationUser> FindUserByEmailAsync(string useremail)
        {
            return await userManager.FindByEmailAsync(useremail);
        }
        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task  SignineAsync(ApplicationUser user)
        {
           await signinManager.SignInAsync(user, false);
        }
        public async Task SignOutAsync()
        {
            await signinManager.SignOutAsync();
        }

    }
}
