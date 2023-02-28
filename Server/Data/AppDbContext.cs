using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductionPremises> ProductionPremises { get; set; }
        public DbSet<TypeOfEquipment> TypesOfEquipment { get; set; }
        public DbSet<Contract> Contracts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductionPremises>()
                .HasMany(p => p.Contract)
                .WithOne(c => c.ProductionPremise)
                .HasForeignKey(c=>c.ProductionPremiseId);

            modelBuilder.Entity<TypeOfEquipment>()
                .HasMany(t => t.Contract)
                .WithOne(c => c.TypeOfEquipment)
                .HasForeignKey(c => c.TypeOfEquipmentId);

        }
    }
}