﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WHApp_API.Data;

namespace WHApp_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WHApp_API.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarCode")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("DriverId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("WHApp_API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RenterId")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RenterId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WHApp_API.Models.ProductForShipping", b =>
                {
                    b.Property<int>("ProductForShippingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductInWarehouseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShipmentDeadline")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductForShippingId");

                    b.HasIndex("ProductInWarehouseId")
                        .IsUnique();

                    b.ToTable("ProductForShipping");
                });

            modelBuilder.Entity("WHApp_API.Models.ProductInWarehouse", b =>
                {
                    b.Property<int>("ProductInWarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("ProductInWarehouseId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("WarehouseId");

                    b.HasIndex("ZoneId");

                    b.ToTable("ProductsInWarehouse");
                });

            modelBuilder.Entity("WHApp_API.Models.ProductShipping", b =>
                {
                    b.Property<int>("ProductShippingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductShippingId");

                    b.HasIndex("CarId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductsForShipping");
                });

            modelBuilder.Entity("WHApp_API.Models.RenterWarehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RenterId")
                        .HasColumnType("int");

                    b.Property<int>("RenterWarehouseId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RenterId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("RenterWarehouses");
                });

            modelBuilder.Entity("WHApp_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");
                });

            modelBuilder.Entity("WHApp_API.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("WHApp_API.Models.Zone", b =>
                {
                    b.Property<int>("ZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.Property<string>("ZoneName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZoneId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("WHApp_API.Models.Admin", b =>
                {
                    b.HasBaseType("WHApp_API.Models.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("WHApp_API.Models.Driver", b =>
                {
                    b.HasBaseType("WHApp_API.Models.User");

                    b.HasDiscriminator().HasValue("Driver");
                });

            modelBuilder.Entity("WHApp_API.Models.Owner", b =>
                {
                    b.HasBaseType("WHApp_API.Models.User");

                    b.HasDiscriminator().HasValue("Owner");
                });

            modelBuilder.Entity("WHApp_API.Models.Renter", b =>
                {
                    b.HasBaseType("WHApp_API.Models.User");

                    b.HasDiscriminator().HasValue("Renter");
                });

            modelBuilder.Entity("WHApp_API.Models.Car", b =>
                {
                    b.HasOne("WHApp_API.Models.Driver", "Driver")
                        .WithMany("Cars")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("WHApp_API.Models.Product", b =>
                {
                    b.HasOne("WHApp_API.Models.Renter", "Renter")
                        .WithMany("Products")
                        .HasForeignKey("RenterId");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("WHApp_API.Models.ProductForShipping", b =>
                {
                    b.HasOne("WHApp_API.Models.ProductInWarehouse", "ProductInWarehouse")
                        .WithOne("ProductForShipping")
                        .HasForeignKey("WHApp_API.Models.ProductForShipping", "ProductInWarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductInWarehouse");
                });

            modelBuilder.Entity("WHApp_API.Models.ProductInWarehouse", b =>
                {
                    b.HasOne("WHApp_API.Models.Product", "Product")
                        .WithOne("ProductInWarehouse")
                        .HasForeignKey("WHApp_API.Models.ProductInWarehouse", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WHApp_API.Models.Warehouse", "Warehouse")
                        .WithMany("ProductsInWarehouse")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WHApp_API.Models.Zone", "Zone")
                        .WithMany("ProductsInWarehouse")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Warehouse");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("WHApp_API.Models.ProductShipping", b =>
                {
                    b.HasOne("WHApp_API.Models.Car", "Car")
                        .WithMany("ProductsForShipping")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WHApp_API.Models.Product", "Product")
                        .WithOne("ProductShipping")
                        .HasForeignKey("WHApp_API.Models.ProductShipping", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WHApp_API.Models.RenterWarehouse", b =>
                {
                    b.HasOne("WHApp_API.Models.Renter", "Renter")
                        .WithMany("RenterWarehouses")
                        .HasForeignKey("RenterId");

                    b.HasOne("WHApp_API.Models.Warehouse", "Warehouse")
                        .WithMany("RenterWarehouses")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Renter");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WHApp_API.Models.Warehouse", b =>
                {
                    b.HasOne("WHApp_API.Models.Owner", "Owner")
                        .WithMany("Warehouses")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("WHApp_API.Models.Zone", b =>
                {
                    b.HasOne("WHApp_API.Models.Warehouse", "Warehouse")
                        .WithMany("Zones")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WHApp_API.Models.Car", b =>
                {
                    b.Navigation("ProductsForShipping");
                });

            modelBuilder.Entity("WHApp_API.Models.Product", b =>
                {
                    b.Navigation("ProductInWarehouse");

                    b.Navigation("ProductShipping");
                });

            modelBuilder.Entity("WHApp_API.Models.ProductInWarehouse", b =>
                {
                    b.Navigation("ProductForShipping");
                });

            modelBuilder.Entity("WHApp_API.Models.Warehouse", b =>
                {
                    b.Navigation("ProductsInWarehouse");

                    b.Navigation("RenterWarehouses");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("WHApp_API.Models.Zone", b =>
                {
                    b.Navigation("ProductsInWarehouse");
                });

            modelBuilder.Entity("WHApp_API.Models.Driver", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WHApp_API.Models.Owner", b =>
                {
                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("WHApp_API.Models.Renter", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("RenterWarehouses");
                });
#pragma warning restore 612, 618
        }
    }
}
