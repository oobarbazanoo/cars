using System.Collections.Generic;

namespace Domain.Reporting.DTO.Response.Cars
{
    public class CarsResponse
    {
        public IEnumerable<Warehouse> Warehouses { get; set; }
        public IEnumerable<Car> AllCars { get; set; }
    }
}