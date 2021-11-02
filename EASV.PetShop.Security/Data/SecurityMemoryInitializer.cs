using System;
using System.ComponentModel.DataAnnotations;
using EASV.PetShop.Security.Authentication;
using EASV.PetShop.Security.Entities;

namespace EASV.PetShop.Security.Data
{
    public class SecurityMemoryInitializer : ISecurityContextInitializer
    {
        public void Initialize(SecurityContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            context.SaveChanges();

            var authenticationHelper = new AuthenticationHelper(Array.Empty<byte>());
            var password = "password123"; //Lol
            
            authenticationHelper.CreatePasswordHash(password, out var pass, out var salt);
            context.Users.Add(new User
            {
                Role = "Administrator",
                Username = "admin",
                PasswordHash = pass,
                PasswordSalt = salt
            });
            context.SaveChanges();
        }
    }
}