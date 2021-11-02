﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EASV.PetShop.Security.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EASV.PetShop.Security.Authentication
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private byte[] secretBytes;

        public AuthenticationHelper(Byte[] secret)
        {
            secretBytes = secret;
        }
        
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(secretBytes),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null,
                    null,
                    claims.ToArray(),
                    DateTime.Now,
                    DateTime.Now.AddMinutes(10)));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}