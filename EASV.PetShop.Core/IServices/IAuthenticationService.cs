using EASV.PetShop.Core.Models;

namespace EASV.PetShop.Core.IServices
{
    public interface IAuthenticationService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);

        string GenerateToken(User user);
    }
}