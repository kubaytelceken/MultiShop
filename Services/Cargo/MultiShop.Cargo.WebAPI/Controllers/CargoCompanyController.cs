using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany();
            cargoCompany.CargoCompanyName = createCargoCompanyDto.CargoCompanyName;
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Cargo Company created successfully");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Cargo Company deleted successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var values = _cargoCompanyService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany();
            cargoCompany.CargoCompanyId = updateCargoCompanyDto.CargoCompanyId;
            cargoCompany.CargoCompanyName = updateCargoCompanyDto.CargoCompanyName;
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Cargo Company updated successfully");
        }
    }
}
