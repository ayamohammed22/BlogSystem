using API_BlogSystem.DTOS;
using CoreLayer_BlogSystem.Entities.Identity;
using CoreLayer_BlogSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API_BlogSystem.Controllers
{
   
    public class AuthController : APIBaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenServices _tokenServices;

        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager , ITokenServices tokenServices ,
                                 SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenServices = tokenServices;
            _signInManager = signInManager;
        }

     

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO model)
        {
            if (EmailIsExist(model.Email).Result)
            {
                return BadRequest(400);
            }
            var User = new AppUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                PasswordHash = model.Password,
                Role = model.Role
            };
            var Result = await _userManager.CreateAsync(User, model.Password);
            if (!Result.Succeeded)
                return BadRequest(400);
            var MappedUser = new UserDTO()
            {

                Email = User.Email,
                Token = await _tokenServices.CreateTokenasync(User, _userManager)
            };
            return MappedUser;

        }

        [HttpPost("Login")]

        public async Task<ActionResult<UserDTO>> Login (LoginDTO Data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(Data.Email);
            if (user is null)
                return Unauthorized();
            var Result = await _signInManager.CheckPasswordSignInAsync(user, Data.Password, false);
            if (!Result.Succeeded)
                return BadRequest(401);
            var MappedUser = new UserDTO()
            {
                Email = Data.Email,
                Username = user.UserName,
                Token = await _tokenServices.CreateTokenasync(user, _userManager)
            };
            return Ok(MappedUser);
        }




        [HttpGet("EmailExist")]
        public async Task<bool> EmailIsExist (string Email)
        {
            return await _userManager.FindByEmailAsync(Email) is not null;
        }


    }
}
