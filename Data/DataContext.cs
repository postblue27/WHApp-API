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
            modelBuilder.Entity<Renter>()
                .HasKey(r => r.UserId);
            modelBuilder.Entity<Owner>()
                .HasKey(o => o.UserId);
            modelBuilder.Entity<RenterWarehouse>()
                .HasOne(rw => rw.Renter)
                .WithMany(r => r.RenterWarehouses)
                .HasForeignKey(rw => rw.UserId);  
            modelBuilder.Entity<RenterWarehouse>()
                .HasOne(rw => rw.Warehouse)
                .WithMany(w => w.RenterWarehouses)
                .HasForeignKey(rw => rw.WarehouseId);

            modelBuilder.Entity<Warehouse>()
                .HasOne(w => w.Owner)
                .WithMany(o => o.OwnerWarehouses)
                .HasForeignKey(w => w.UserId);
        }
    }
}