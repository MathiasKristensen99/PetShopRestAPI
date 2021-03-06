using System.Collections.Generic;
using EASV.PetShop.Core.Models;

namespace EASV.PetShop.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance GetById(int id);
        
        List<Insurance> ReadAllInsurances();
        
        Insurance CreateInsurance(Insurance insurance);

        Insurance DeleteInsurance(int id);

        Insurance UpdateInsurance(Insurance insurance, int id);
    }
}