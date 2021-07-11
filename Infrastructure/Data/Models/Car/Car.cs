using System;
using WarehouseModel = Infrastructure.Data.Models.Warehouse.Warehouse;

namespace Infrastructure.Data.Models.Car
{
    public class Car
    {
        public int WarehouseId { get; set; }
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearModel { get; set; }
        public decimal Price { get; set; }
        public bool Licensed { get; set; }
        public DateTimeOffset Added { get; set; }

        public WarehouseModel Warehouse { get; set; }
    }
}