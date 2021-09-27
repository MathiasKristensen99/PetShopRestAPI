using System.Collections.Generic;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;

namespace EASV.PetShop.Domain.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }
        
        public List<User> ReadAllUsers()
        {
            return _userRepository.ReadAllUsers();
        }

        public User GetUserById(long id)
        {
            return _userRepository.GetUserById(id);
        }

        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public User DeleteUser(User user)
        {
            return _userRepository.DeleteUser(user);
        }
    }
}