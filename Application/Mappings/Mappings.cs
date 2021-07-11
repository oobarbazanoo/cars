using Mapster;
using CarDataModel = Infrastructure.Data.Models.Car.Car;
using Domain.Reporting.DTO.Response.Car;

namespace Application.Mappings
{
    public class Mappings
    {
        public static void Register()
        {
            TypeAdapterConfig<CarDataModel, CarResponse>.NewConfig()
                .MapWith(src => new CarResponse
                {
                    WarehouseId = src.WarehouseId,
                    Id = src.Id,
                    Make = src.Make,
                    Model = src.Model,
                    YearModel = src.YearModel,
                    Price = src.Price,
                    Licensed = src.Licensed,
                    Added = src.Added
                });
        }
    }
}