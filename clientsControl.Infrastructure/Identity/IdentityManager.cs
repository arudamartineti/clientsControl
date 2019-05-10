using clientsControl.Application.Interfaces;
using clientsControl.Domain.Entities;
using clientsControl.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace clientsControl.Infrastructure.Identity
{
    public class IdentityManager : IIdentityManager
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private RoleManager<IdentityRole> roleManager { get; set; }
        private SignInManager<ApplicationUser> signInManager { get; set; }
        private IConfiguration configuration { get; set; }
        private clientsControlDbContext db { get; set; }

        public IdentityManager(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, clientsControlDbContext db)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.db = db;
        }

        public object authenticatheUser(string userName, string userPassword)
        {
            throw new NotImplementedException();
        }

        public object authorizeUser(string userName)
        {
            throw new NotImplementedException();
        }

        public object buildToken(string user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, user),
                new Claim(JwtRegisteredClaimNames.Email, user),
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

            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            };
        }

        public object registerUser(string userName, string userEmail, string userPassword)
        {
            throw new NotImplementedException();
        }
    }
}
