using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositorypattern.core.Models;
using Repositorypattern.core.UnitofWork;
using Repositorypattern.ef;
using RepositoryPattern.ef;
using RepositoryPattern.ef.Repositories;
using WebApplication1.Dtos;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(UserManager<ApplicationUser> userManager,
              SignInManager<ApplicationUser> signInManager, IAccountRepository accountRepository)
        {
           this.accountRepository = accountRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register(Registeruser newuser)
        {
            if(ModelState.IsValid)
            {
                var result =await accountRepository.FindUserByEmailAsync(newuser.Email);


                if (result == null)
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        UserName= newuser.FirstName+"_"+ newuser.FirstName,
                        Email=newuser.Email,
                        Address= newuser.Address
                    };

                    var finalresult = await accountRepository.RegisterUserAsync(user, newuser.Password);
                    if (finalresult.Succeeded)
                    {
                        return Created();
                    }
                    else
                    {

                        var errorMessages = finalresult.Errors.Select(e => e.Description).ToList();
                        return BadRequest(new { Message = "Invalid data", Errors = errorMessages });
                    }

                   }
                else
                {
                    return BadRequest("email is already token");
                }
            
            }

            return BadRequest("invalid data");
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginUser User)
        { if(ModelState.IsValid)
            {
                var result =await accountRepository.FindUserByEmailAsync(User.Email);
                if (result != null) {


                    var finalresult =await accountRepository.CheckPasswordAsync(result, User.Password);
                    if (finalresult)
                    {
                        await accountRepository.SignineAsync(result);
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("wrong password");
                    } 
                }
              else  {
                    return BadRequest("there is no email");
                }

            }
            else
            {
                return BadRequest("invalid data");
            }


        }

        [HttpPost("signout")]
        public async Task<IActionResult> signout()
        {
            await accountRepository.SignOutAsync();

            return Ok("sign out succeefully");
        }


    }
}
