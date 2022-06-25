using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WHApp_API.Dtos;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Helpers
{
    public class DataInitializer
    {
        public static async Task InitializeAsync(IAuthRepository authRepo, IWarehouseRepository warehouseRepo, IAppRepository appRepo)
        {
            //admin seeding
            if (!await authRepo.UserExistsAsync("admin"))
            {
                await authRepo.RegisterAsync(new UserForRegisterDto{Username = "admin", UserType = UserTypes.Admin, Email = "admin@gmail.com", Password = "password"});
            }
            //renter seeding
            if (!await authRepo.UserExistsAsync("new-renter"))
            {
                await authRepo.RegisterAsync(new UserForRegisterDto{Username = "new-renter", UserType = UserTypes.Renter, Email = "renter@gmail.com", Password = "password"});
            }
            //owner seeding
            if (!await authRepo.UserExistsAsync("nazar"))
            {
                await authRepo.RegisterAsync(new UserForRegisterDto{Username = "nazar", UserType = UserTypes.Owner, Email = "owner@gmail.com", Password = "password"});
            }
            //driver seeding
            if (!await authRepo.UserExistsAsync("new-driver"))
            {
                await authRepo.RegisterAsync(new UserForRegisterDto{Username = "new-driver", UserType = UserTypes.Driver, Email = "driver@gmail.com", Password = "password"});
            }
            //warehouse seeding
            var owner = await authRepo.GetUser("nazar");
            var warehouses = new List<Warehouse>
            {
                new Warehouse{ Name = "Mega Warehouse", Capacity = 1000, Country = "Ukraine", City = "Kharkiv", Latitude = "49.992776322184476", Longitude = "36.242257151514345", Cost = 25, OwnerId = owner.Id },
                new Warehouse{ Name = "Super Warehouse", Capacity = 1000, Country = "Ukraine", City = "Lviv", Latitude = "49.83943331622614", Longitude = "24.025941929376646", Cost = 35, OwnerId = owner.Id },
                new Warehouse{ Name = "Warehouse - 2000", Capacity = 1000, Country = "Ukraine", City = "Kiev", Latitude = "50.45378529740858", Longitude = "30.513579412604532", Cost = 45, OwnerId = owner.Id },
                new Warehouse{ Name = "Warehouse - Agano", Capacity = 1000, Country = "Japan", City = "Agano", Latitude = "37.83396009282357", Longitude = "139.21791746990277", Cost = 40, OwnerId = owner.Id },
                new Warehouse{ Name = "Warehouse - Tokio", Capacity = 1000, Country = "Japan", City = "Tokio", Latitude = "35.68655227003403", Longitude = "139.72814679282737", Cost = 37, OwnerId = owner.Id },
                new Warehouse{ Name = "Warehouse - Akasaki", Capacity = 1000, Country = "Japan", City = "Akasaki", Latitude = "35.960170245511556", Longitude = "139.80400954914222", Cost = 29, OwnerId = owner.Id },
            };
            foreach (var w in warehouses)
            {
                appRepo.Add(w);
            }
        }
    }
}