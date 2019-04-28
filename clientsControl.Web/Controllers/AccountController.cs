using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using clientsControl.Application.Users.Commands.UserRegister;
using clientsControl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clientsControl.Web.Controllers
{
    public class AccountController : BaseController
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private RoleManager<IdentityRole> roleManager { get; set; }
        private SignInManager<ApplicationUser> signInManager { get; set; }
        private IConfiguration configuration { get; set; }

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterCommand command)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = command.userEmail, Email = command.userEmail };
                var result = await userManager.CreateAsync(user, command.userPassword);

                if (result.Succeeded)
                {
                    return BuildToken(command);
                }
                else
                {
                    BadRequest("Username or password invalid");
                }
            }

            return BadRequest(ModelState.ToString());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserRegisterCommand command)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = command.userEmail, Email = command.userEmail };
                var result = await signInManager.PasswordSignInAsync(user, command.userPassword, true, false);

                if (result.Succeeded)
                {
                    return BuildToken(command);
                }
                else
                {
                    BadRequest("Login incorrecto");
                }

            }

            return BadRequest(ModelState.ToString());
        }

        private IActionResult BuildToken(UserRegisterCommand command)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, command.userEmail),
                new Claim(JwtRegisteredClaimNames.Email, command.userEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.Now.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: expiration,
                    signingCredentials: credentials
                );

            return Ok(new {
                token = new JwtSecurityTokenHandler().WriteToken(token), 
                expiration = expiration
            });
            
        }
    }
}
