using System.Net;
using System.Net.Http;
using Application.DTO.Request;
using Domain.Reporting.DTO.Response.Car;
using Domain.Reporting.DTO.Response.Cars;
using FluentAssertions;
using Infrastructure.Data.Configuration;
using Infrastructure.Data.Seed.Warehouses;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tests.Integration.Base;
using Xbehave;

namespace Tests.Integration.Scenarios
{
    public class Cars : BaseScenario
    {
        [Scenario]
        public void Get_Cars_Should_Return_Cars()
        {
            IHost host = null;
            HttpResponseMessage response = null;

            "Given the host".x(async stepContext => host = await GetHost());
            "And given the seed data".x(async stepContext =>
            {
                using var scope = host.Services.CreateScope();
                var dbContext =
                    (CarsDbContext)(scope.ServiceProvider.GetService(typeof(CarsDbContext)));
                await dbContext.Database.EnsureCreatedAsync();
            });
            "When a GET is made".x(async stepContext =>
            {
                response = await host.GetTestClient().GetAsync("cars");
            });
            "Then the status OK is returned".x(stepContext =>
            {
                response.Should().NotBeNull();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            });
            "And the cars along with warehouses are returned as well".x(async stepContext =>
            {
                var carsResponse = await DeserializeResponseContent<CarsResponse>(response);
                carsResponse.Warehouses.Should().NotBeEmpty();
                carsResponse.AllCars.Should().NotBeEmpty();
            });
        }

        [Scenario]
        public void Get_Car_Should_Return_A_Car()
        {
            IHost host = null;
            HttpResponseMessage response = null;
            var request = new GetCarRequest
            {
                WarehouseId = 1,
                CarId = 1
            };

            "Given the host".x(async stepContext => host = await GetHost());
            "And given the seed data".x(async stepContext =>
            {
                using var scope = host.Services.CreateScope();
                var dbContext =
                    (CarsDbContext)(scope.ServiceProvider.GetService(typeof(CarsDbContext)));
                await dbContext.Database.EnsureCreatedAsync();
            });
            "When a POST is made".x(async stepContext =>
            {
                response = await host.GetTestClient().PostAsync("car", GetStringContent(request));
            });
            "Then the status OK is returned".x(stepContext =>
            {
                response.Should().NotBeNull();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            });
            "And the car is returned as well".x(async stepContext =>
            {
                var carResponse = await DeserializeResponseContent<CarResponse>(response);
                carResponse.WarehouseId.Should().Be(request.WarehouseId);
                carResponse.Id.Should().Be(request.CarId);
            });
        }
    }
}