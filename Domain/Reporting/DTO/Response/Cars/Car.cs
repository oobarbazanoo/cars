using System;

namespace Domain.Reporting.DTO.Response.Cars
{
    public class Car
    {
        public int WarehouseId { get; set; }
        public int Id { get; set; }
        public string Model { get; set; }
        public bool Licensed { get; set; }
        public DateTimeOffset Added { get; set; }
    }
}