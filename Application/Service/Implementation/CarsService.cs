using Application.DTO.Request;
using Application.Service.Interface;
using System.Threading.Tasks;
using Domain.Reporting.Service.Interface;
using Domain.Reporting.DTO.Response.Cars;
using Domain.Reporting.DTO.Response.Car;

namespace Application.Service.Implementation
{
    public class CarsService : ICarsService
    {
        readonly ICarsRepository Repository;

        public CarsService(ICarsRepository repository)
        {
            Repository = repository;
        }

        public async Task<CarsResponse> GetCars() =>
            await Repository.GetCars();

        public async Task<CarResponse> GetCar(GetCarRequest request) =>
            await Repository.GetCar(request.WarehouseId, request.CarId);
    }
}