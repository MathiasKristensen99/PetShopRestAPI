﻿using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace EASV.PetShop.Security.Data
{
    public class UserRepository
    {
        private readonly SecurityContext _context;

        public UserRepository(SecurityContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Get(long id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var item = Get(id);
            _context.Users.Remove(item);
            _context.SaveChanges();
        }
    }
}