using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.Dto.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCompanyService)
        {
            _cargoCustomerService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {

            CargoCustomer cargoCustomer = new CargoCustomer();
            cargoCustomer.Name = createCargoCustomerDto.Name;
            cargoCustomer.Surname = createCargoCustomerDto.Surname;
            cargoCustomer.Email = createCargoCustomerDto.Email;
            cargoCustomer.Phone = createCargoCustomerDto.Phone;
            cargoCustomer.District = createCargoCustomerDto.District;
            cargoCustomer.City = createCargoCustomerDto.City;
            cargoCustomer.Address = createCargoCustomerDto.Address;
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Cargo Customer created successfully");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Cargo Customer deleted successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer();
            cargoCustomer.CargoCustomerId = updateCargoCustomerDto.CargoCustomerId;
            cargoCustomer.Name = updateCargoCustomerDto.Name;
            cargoCustomer.Surname = updateCargoCustomerDto.Surname;
            cargoCustomer.Email = updateCargoCustomerDto.Email;
            cargoCustomer.Phone = updateCargoCustomerDto.Phone;
            cargoCustomer.District = updateCargoCustomerDto.District;
            cargoCustomer.City = updateCargoCustomerDto.City;
            cargoCustomer.Address = updateCargoCustomerDto.Address;
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Cargo Customer updated successfully");
        }
    }
}
