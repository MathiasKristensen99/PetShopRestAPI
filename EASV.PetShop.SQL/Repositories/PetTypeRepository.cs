using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;
using EASV.PetShop.SQL.Entities;

namespace EASV.PetShop.SQL.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly PetShopDBContext _ctx;

        public PetTypeRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public List<PetType> GetAllPetTypes()
        {
            return _ctx.PetTypes.Select(entity => new PetType
            {
                Id = entity.Id,
                Name = entity.Name
            }).ToList();
        }

        public PetType GetPetType(int id)
        {
            throw new System.NotImplementedException();
        }

        public PetType DeletePetType(int id)
        {
            var entity = _ctx.PetTypes.Remove(new PetTypeEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new PetType
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}