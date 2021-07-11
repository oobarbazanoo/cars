using Application.DTO.Request;
using System.Threading.Tasks;
using Domain.Reporting.DTO.Response.Car;
using Domain.Reporting.DTO.Response.Cars;

namespace Application.Service.Interface
{
    public interface ICarsService
    {
        Task<CarsResponse> GetCars();
        Task<CarResponse> GetCar(GetCarRequest request);
    }
}