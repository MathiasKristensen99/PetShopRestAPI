using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.SQL.Entities;

namespace EASV.PetShop.SQL.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly PetShopDBContext _ctx;
        private List<Insurance> insurances = new List<Insurance>();

        public InsuranceRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public Insurance GetById(int id)
        {
            return _ctx.Insurances
                .Select(insuranceEntity => new Insurance
                {
                    Id = insuranceEntity.Id,
                    Name = insuranceEntity.Name
                })
                .FirstOrDefault(insurance => insurance.Id == id);
        }

        public List<Insurance> GetAllInsurances()
        {
            throw new NotImplementedException();
        }

        public Insurance CreateInsurance(Insurance insurance)
        {
            var entity = _ctx.Add(new InsuranceEntity
            {
                Name = insurance.Name
            }).Entity;
            
            _ctx.SaveChanges();
            
            return new Insurance
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}