using System.Net;
using System.Threading.Tasks;
using Application.DTO.Request;
using Application.Service.Interface;
using Domain.Reporting.DTO.Response.Car;
using Domain.Reporting.DTO.Response.Cars;
using Microsoft.AspNetCore.Mvc;
using API.Security;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    public class Cars : ControllerBase
    {
        readonly ICarsService Service;
        public Cars(ICarsService service)
        {
            Service = service;
        }

        [HttpGet("cars")]
        [ProducesResponseType(typeof(CarsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetCars() => Ok(await Service.GetCars());

        [HttpPost("car")]
        [ProducesResponseType(typeof(CarResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Login(GetCarRequest request) => Ok(await Service.GetCar(request));
    }
}