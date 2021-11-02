

using EASV.PetShop.Security.Entities;

namespace EASV.PetShop.Security.Authentication
{
    public interface IAuthenticationHelper
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);

        string GenerateToken(User user);
    }
}