using EASV.PetShop.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace EASV.PetShop.Security.Data
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions contextOptions) : base(contextOptions)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
    }
}