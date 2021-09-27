using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;

namespace EASV.PetShop.SQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetShopDBContext _ctx;

        public UserRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public List<User> ReadAllUsers()
        {
            return _ctx.Users.Select(userEntity => new User
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                IsAdmin = userEntity.IsAdmin,
                PasswordHash = userEntity.PasswordHash,
                PasswordSalt = userEntity.PasswordSalt
            }).ToList();
        }

        public User GetUserById(long id)
        {
            return _ctx.Users.Select(userEntity => new User()
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                IsAdmin = userEntity.IsAdmin
            }).FirstOrDefault(user => user.Id == id);
        }

        public User CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public User DeleteUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}