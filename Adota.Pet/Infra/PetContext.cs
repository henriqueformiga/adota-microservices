using Microsoft.EntityFrameworkCore;
using PetModel = Adota.Pet.Domain.Entities.Pet;

namespace Adota.Pet.Infra
{
    public class PetContext : DbContext
    {
        public PetContext(){}
        public PetContext(DbContextOptions opts) : base(opts){}


        public DbSet<PetModel> Pet {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder){
            modelBuilder.Entity<PetModel>(b => {b.ToTable("pet");});
        }


    }
}
