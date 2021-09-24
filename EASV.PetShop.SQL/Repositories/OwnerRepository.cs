using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.SQL.Entities;

namespace EASV.PetShop.SQL.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetShopDBContext _ctx;

        public OwnerRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public List<Owner> ReadAllOwners()
        {
            return _ctx.Owners.Select(entity => new Owner
            {
                Id = entity.Id,
                Name = entity.Name
            }).ToList();
        }

        public Owner CreateOwner(Owner owner)
        {
            var entity = _ctx.Add(new OwnerEntity
            {
                Id = owner.Id,
                Name = owner.Name
            }).Entity;

            _ctx.SaveChanges();

            return new Owner
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Owner UpdateOwnerName(int id, string name)
        {
            var entity = _ctx.Update(new OwnerEntity
            {
                Id = id,
                Name = name
            }).Entity;

            _ctx.SaveChanges();

            return new Owner
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Owner DeleteOwner(int id)
        {
            var entity = _ctx.Owners.Remove(new OwnerEntity {Id = id}).Entity;
            _ctx.SaveChanges();

            return new Owner
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Owner GetOwnerById(int id)
        {
            return _ctx.Owners.Select(entity => new Owner
            {
                Id = entity.Id,
                Name = entity.Name
            }).FirstOrDefault(owner => owner.Id == id);
        }
    }
}