using System;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.WebApi.Dtos
{
    public class PostPetDto
    {
        public string Name { get; set; }
        public int PetTypeId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int OwnerId { get; set; }
        public int InsuranceId { get; set; }
    }
}