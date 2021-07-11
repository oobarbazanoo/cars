using Domain.Reporting.DTO.Response.Car;
using Domain.Reporting.DTO.Response.Cars;
using System.Threading.Tasks;

namespace Domain.Reporting.Service.Interface
{
    public interface ICarsRepository
    {
        Task<CarsResponse> GetCars();
        Task<CarResponse> GetCar(int warehouseId, int carId);
    }
}
