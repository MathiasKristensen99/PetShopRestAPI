using System.Collections.Generic;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;

namespace EASV.PetShop.Domain.Services
{
    public class InsuranceService : IInsuranceService
    {
        private IInsuranceRepository _insuranceRepository;
        
        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public Insurance GetById(int id)
        {
            return _insuranceRepository.GetById(id);
        }

        public List<Insurance> ReadAllInsurances()
        {
            return _insuranceRepository.ReadAllInsurances();
        }

        public Insurance CreateInsurance(Insurance insurance)
        {
            return _insuranceRepository.CreateInsurance(insurance);
        }

        public Insurance DeleteInsurance(int id)
        {
            return _insuranceRepository.DeleteInsurance(id);
        }

        public Insurance UpdateInsurance(Insurance insurance, int id)
        {
            return _insuranceRepository.UpdateInsurance(insurance, id);
        }
    }
}