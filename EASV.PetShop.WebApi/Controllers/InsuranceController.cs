using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EASV.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;
        
        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet]
        public ActionResult<List<Insurance>> ReadAllInsurances()
        {
            try
            {
                return Ok(_insuranceService.ReadAllInsurances());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Du har fucked op");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Insurance> GetById(int id)
        {
            try
            {
                return Ok(_insuranceService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Du har fucked op");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Insurance> DeleteInsurance(int id)
        {
            try
            {
                return Ok(_insuranceService.DeleteInsurance(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Du har fucked op");
            }
        }

        [HttpPost]
        public ActionResult<Insurance> CreateInsurance ([FromBody] Insurance insurance)
        {
            try
            {
                return Ok(_insuranceService.CreateInsurance(insurance));
            }
            catch (Exception e)
            {
                StatusCode(500, "Du har fucked up");
            }

            return null;
        }

        [HttpPut("{id}")]
        public ActionResult<Insurance> UpdateInsurance([FromBody] Insurance insurance, int id)
        {
            try
            {
                if (id != insurance.Id)
                {
                    return BadRequest("Id doesnt match Id from insurance");
                }
                
                return Ok(_insuranceService.UpdateInsurance(insurance, id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Du har fucked op");
            }
        }
    }
}