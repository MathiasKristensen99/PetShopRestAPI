using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EASV.PetShop.SQL.Entities
{
    public class InsuranceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}