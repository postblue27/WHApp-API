using Microsoft.EntityFrameworkCore;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
        public DbSet<User> Users { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<RenterWarehouse> RenterWarehouses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShippingRequest> ShippingRequests { get; set; }
        // public DbSet<ProductInWarehouse> ProductsInWarehouse { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator(u => u.UserType);
            // //users and warehouse relations
            // modelBuilder.Entity<Owner>()
            //     .HasKey(o => o.Id);
            // modelBuilder.Entity<Renter>()
            //     .HasKey(r => r.Id);
            // modelBuilder.Entity<Driver>()
            //     .HasKey(d => d.Id);
            // modelBuilder.Entity<Admin>()
            //     .HasKey(a => a.Id);

            // modelBuilder.Entity<Owner>()
            //     .HasMany(o => o.Warehouses)
            //     .WithOne(w => w.Owner)
            //     .HasForeignKey(w => w.OwnerId)
            //     .OnDelete(DeleteBehavior.Cascade);
            // modelBuilder.Entity<Renter>()
            //     .HasMany(r => r.RenterWarehouses)
            //     .WithOne(rw => rw.Renter)
            //     // .HasForeignKey(rw => rw.RenterId)
            //     .HasForeignKey(rw => rw.Id)
            //     .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.RenterWarehouses)
                .WithOne(rw => rw.Warehouse)
                .HasForeignKey(rw => rw.WarehouseId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ShippingRequest>()
                .HasOne(sr => sr.Product)
                .WithOne(p => p.ShippingRequest)
                .HasForeignKey<ShippingRequest>(sr => sr.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ShippingRequest>()
                .HasOne(sr => sr.Warehouse)
                .WithMany(w => w.ShippingRequests)
                .HasForeignKey(sr => sr.WarehouseId)
                .OnDelete(DeleteBehavior.NoAction);
            // modelBuilder.Entity<Driver>()
            //     .HasMany(d => d.Cars)
            //     .WithOne(c => c.Driver)
            //     .HasForeignKey(c => c.DriverId)
            //     .OnDelete(DeleteBehavior.Cascade);
            
            // //user and product relations
            // modelBuilder.Entity<Renter>()
            //     .HasMany(r => r.Products)
            //     .WithOne(p => p.Renter)
            //     .HasForeignKey(p => p.Id)
            //     .OnDelete(DeleteBehavior.Cascade);

            // //car and product relations
            // modelBuilder.Entity<Car>()
            //     .HasMany(c => c.ProductsForShipping)
            //     .WithOne(pfs => pfs.Car)
            //     .HasForeignKey(pfs => pfs.CarId)
            //     .OnDelete(DeleteBehavior.NoAction);
            // modelBuilder.Entity<Product>()
            //     .HasOne(p => p.ProductShipping)
            //     .WithOne(pfs => pfs.Product)
            //     .HasForeignKey<ProductShipping>(pfs => pfs.ProductId)
            //     .OnDelete(DeleteBehavior.NoAction);
            
            // //warehouse and product relations
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Warehouse)
                .WithMany(w => w.Products)
                // .HasForeignKey(p => p.WarehouseId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            // modelBuilder.Entity<Product>()
            //     .HasOne(p => p.ProductInWarehouse)
            //     .WithOne(piw => piw.Product)
            //     .HasForeignKey<ProductInWarehouse>(piw => piw.ProductId)
            //     .OnDelete(DeleteBehavior.Cascade);
            
            // //warehouse and zone relations
            // modelBuilder.Entity<Warehouse>()
            //     .HasMany(w => w.Zones)
            //     .WithOne(z => z.Warehouse)
            //     .HasForeignKey(z => z.WarehouseId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // //product for shipping relations
            // modelBuilder.Entity<ProductInWarehouse>()
            //     .HasOne(p => p.ProductForShipping)
            //     .WithOne(pfs => pfs.ProductInWarehouse)
            //     .HasForeignKey<ProductForShipping>(pfs => pfs.ProductInWarehouseId)
            //     .OnDelete(DeleteBehavior.Cascade);
        }
        
    }   
}