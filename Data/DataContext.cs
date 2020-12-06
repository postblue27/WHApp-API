using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, 
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<RenterWarehouse> RenterWarehouses { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductShipping> ProductsForShipping { get; set; }
        public DbSet<ProductInWarehouse> ProductsInWarehouse { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole => {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();    
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired(); 
            });

            //users and warehouse relations

            modelBuilder.Entity<User>()
                .HasMany(o => o.OwnerWarehouses)
                .WithOne(w => w.Owner)
                .HasForeignKey(w => w.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(r => r.RenterWarehouses)
                .WithOne(rw => rw.Renter)
                // .HasForeignKey(rw => rw.RenterId)
                .HasForeignKey(rw => rw.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.RenterWarehouses)
                .WithOne(rw => rw.Warehouse)
                .HasForeignKey(rw => rw.WarehouseId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasMany(d => d.DriverCars)
                .WithOne(c => c.Driver)
                .HasForeignKey(c => c.DriverId)
                .OnDelete(DeleteBehavior.Cascade);
            
            //user and product relations
            modelBuilder.Entity<User>()
                .HasMany(r => r.RenterProducts)
                .WithOne(p => p.Renter)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //car and product relations
            modelBuilder.Entity<Car>()
                .HasMany(c => c.ProductsForShipping)
                .WithOne(pfs => pfs.Car)
                .HasForeignKey(pfs => pfs.CarId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductShipping)
                .WithOne(pfs => pfs.Product)
                .HasForeignKey<ProductShipping>(pfs => pfs.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            
            //warehouse and product relations
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.ProductsInWarehouse)
                .WithOne(piw => piw.Warehouse)
                .HasForeignKey(piw => piw.WarehouseId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductInWarehouse)
                .WithOne(piw => piw.Product)
                .HasForeignKey<ProductInWarehouse>(piw => piw.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            
            //warehouse and zone relations
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.Zones)
                .WithOne(z => z.Warehouse)
                .HasForeignKey(z => z.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);
            
            //product and zone relations
            modelBuilder.Entity<Zone>()
                .HasMany(z => z.ProductsInWarehouse)
                .WithOne(piw => piw.Zone)
                .HasForeignKey(piw => piw.ZoneId)
                .OnDelete(DeleteBehavior.NoAction);

            //product for shipping relations
            modelBuilder.Entity<ProductInWarehouse>()
                .HasOne(p => p.ProductForShipping)
                .WithOne(pfs => pfs.ProductInWarehouse)
                .HasForeignKey<ProductForShipping>(pfs => pfs.ProductInWarehouseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}