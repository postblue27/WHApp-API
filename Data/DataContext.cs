using Microsoft.EntityFrameworkCore;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<RenterWarehouse> RenterWarehouses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasKey(o => o.UserId);
            modelBuilder.Entity<Renter>()
                .HasKey(r => r.UserId);

            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Warehouses)
                .WithOne(w => w.Owner)
                .HasForeignKey(w => w.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Renter>()
                .HasMany(r => r.RenterWarehouses)
                .WithOne(rw => rw.Renter)
                .HasForeignKey(rw => rw.RenterId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.RenterWarehouses)
                .WithOne(rw => rw.Warehouse)
                .HasForeignKey(rw => rw.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}