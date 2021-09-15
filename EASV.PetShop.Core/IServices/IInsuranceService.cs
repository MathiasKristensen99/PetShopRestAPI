﻿using System.Collections.Generic;
using EASV.PetShop.Core.Models;

namespace EASV.PetShop.Core.IServices
{
    public interface IInsuranceService
    {
        Insurance GetById(int id);

        List<Insurance> GetAllInsurances();

        Insurance CreateInsurance(Insurance insurance);
    }
}