using Microsoft.EntityFrameworkCore;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
        // public DbSet<Owner> Owners { get; set; }
        // public DbSet<Renter> Renters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<RenterWarehouse> RenterWarehouses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<Warehouse>()
            //     .HasOne(w => w.Owner)
            //     .WithMany(o => o.OwnerWarehouses)
            //     .HasForeignKey(w => w.UserId);
            // modelBuilder.Entity<RenterWarehouse>()
            //     .HasOne(rw => rw.User)
            //     .WithMany(r => r.RenterWarehouses)
            //     .HasForeignKey(rw => rw.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);  
            // modelBuilder.Entity<RenterWarehouse>()
            //     .HasOne(rw => rw.Warehouse)
            //     .WithMany(w => w.RenterWarehouses)
            //     .HasForeignKey(rw => rw.WarehouseId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<Warehouse>()
            //     .HasOne(w => w.User)
            //     .WithMany(o => o.UserWarehouses)
            //     .HasForeignKey(w => w.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserWarehouses)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.RenterWarehouses)
                .WithOne(rw => rw.User)
                .HasForeignKey(rw => rw.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.RenterWarehouses)
                .WithOne(rw => rw.Warehouse)
                .HasForeignKey(rw => rw.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Warehouse>()
                .HasOne(w => w.User)
                .WithMany(u => u.UserWarehouses)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}