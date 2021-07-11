using System;

namespace Domain.Reporting.DTO.Response.Car
{
    public class CarResponse
    {
        public int WarehouseId { get; set; }
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearModel { get; set; }
        public decimal Price { get; set; }
        public bool Licensed { get; set; }
        public DateTimeOffset Added { get; set; }

        public string WarehouseName { get; set; }
        public string WarehouseLocation { get; set; }
    }
}