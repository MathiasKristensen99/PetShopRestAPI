using System.Collections.Generic;
using EASV.PetShop.Core.Models;

namespace EASV.PetShop.Core.IServices
{
    public interface IUserService
    {
        List<User> ReadAllUsers();

        User GetUserById(long id);

        User CreateUser(User user);

        User UpdateUser(User user);

        User DeleteUser(User user);
    }
}