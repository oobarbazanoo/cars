using System.Collections.Generic;
using CarModel = Infrastructure.Data.Models.Car.Car;

namespace Infrastructure.Data.Models.Warehouse
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        public ICollection<CarModel> Cars;
    }
}