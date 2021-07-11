using Domain.Reporting.DTO.Response.Car;
using Domain.Reporting.DTO.Response.Cars;
using Domain.Reporting.Service.Interface;
using Infrastructure.Data.Configuration;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        readonly CarsDbContext Context;

        public CarsRepository(CarsDbContext context)
        {
            Context = context;
        }

        public async Task<CarResponse> GetCar(int warehouseId, int carId)
        {
            var car = await Context.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.WarehouseId == warehouseId && c.Id == carId && c.Licensed);

            if (car == null)
            {
                return null;
            }

            var res = car?.Adapt<CarResponse>();

            var warehouse = await Context.Warehouses
                .AsNoTracking()
                .Where(w => w.Id == warehouseId)
                .Select(w => new { w.Name, w.Location })
                .FirstOrDefaultAsync();

            res.WarehouseName = warehouse.Name;
            res.WarehouseLocation = warehouse.Location;

            return res;
        }

        public async Task<CarsResponse> GetCars()
        {
            var res = new CarsResponse();

            res.Warehouses = await Context.Warehouses
                .AsNoTracking()
                .Select(w => new Warehouse
                {
                    Id = w.Id,
                    Name = w.Name,
                    Location = w.Location
                })
                .ToListAsync();

            res.AllCars = await Context.Cars
                .AsNoTracking()
                .Select(c => new Car
                {
                    WarehouseId = c.WarehouseId,
                    Id = c.Id,
                    Licensed = c.Licensed,
                    Added = c.Added,
                    Model = c.Model
                })
                .ToListAsync();

            return res;
        }
    }
}