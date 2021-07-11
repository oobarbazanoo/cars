using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Collections.Generic;
using Infrastructure.Data.Models.Warehouse;
using Infrastructure.Data.Models.Car;

namespace Infrastructure.Data.Seed.Warehouses
{
    public class WarehousesAndCarsSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var (warehousesData, carsData) = GetSeedData();
            builder.Entity<Warehouse>().HasData(warehousesData);
            builder.Entity<Car>().HasData(carsData);
        }

        static (List<Warehouse> warehouses, List<Car> cars) GetSeedData()
        {
            var warehousesData = new List<Warehouse>();
            var carsData = new List<Car>();

            var json = GetSeedJson();
            var warehouses = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);
            foreach (var warehouse in warehouses)
            {
                var location = (JsonElement)warehouse["location"];
                var cars = (JsonElement)warehouse["cars"];
                var vehicles = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(cars.GetProperty("vehicles").ToString());

                var w = new Warehouse
                {
                    Id = int.Parse(((JsonElement)warehouse["_id"]).ToString()),
                    Name = ((JsonElement)warehouse["name"]).ToString(),
                    Location = cars.GetProperty("location").ToString(),
                    Lat = double.Parse(location.GetProperty("lat").ToString()),
                    Long = double.Parse(location.GetProperty("long").ToString()),
                    Cars = new List<Car>()
                };
                warehousesData.Add(w);

                foreach (var vehicle in vehicles)
                {
                    carsData.Add(
                        new Car
                        {
                            WarehouseId = w.Id,
                            Id = int.Parse(((JsonElement)vehicle["_id"]).ToString()),
                            Make = ((JsonElement)vehicle["make"]).ToString(),
                            Model = ((JsonElement)vehicle["model"]).ToString(),
                            YearModel = int.Parse(((JsonElement)vehicle["year_model"]).ToString()),
                            Price = decimal.Parse(((JsonElement)vehicle["price"]).ToString()),
                            Licensed = bool.Parse(((JsonElement)vehicle["licensed"]).ToString()),
                            Added = DateTimeOffset.Parse(((JsonElement)vehicle["date_added"]).ToString())
                        }
                    );
                }
            }

            return (warehousesData, carsData);
        }

        static string GetSeedJson()
        {
            var assembly = typeof(WarehousesAndCarsSeeder).GetTypeInfo().Assembly;
            var resourceName = assembly.GetManifestResourceNames()
                .First(s => s.EndsWith("warehouses.json", StringComparison.CurrentCultureIgnoreCase));

            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new InvalidOperationException("Could not load manifest resource stream.");
            }
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}