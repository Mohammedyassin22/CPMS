using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore;

namespace Presistence.Identity
{
    public class CPMS_Identity : IdentityDbContext<AppUsers>
    {
        public CPMS_Identity(DbContextOptions<CPMS_Identity> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Address>().ToTable("Address");
        }
    }
}
