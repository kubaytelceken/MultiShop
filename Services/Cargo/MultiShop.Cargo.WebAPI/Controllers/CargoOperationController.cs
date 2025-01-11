using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoOperationDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoCompanyService;

        public CargoOperationController(ICargoOperationService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoCompany = new CargoOperation();
            cargoCompany.Barcode = createCargoOperationDto.Barcode;
            cargoCompany.Description = createCargoOperationDto.Description;
            cargoCompany.OperationDate = createCargoOperationDto.OperationDate;
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Cargo Operation created successfully");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Cargo Operation deleted successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var values = _cargoCompanyService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoCompany = new CargoOperation();
            cargoCompany.CargoOperationId = updateCargoOperationDto.CargoOperationId;
            cargoCompany.Barcode = updateCargoOperationDto.Barcode;
            cargoCompany.Description = updateCargoOperationDto.Description;
            cargoCompany.OperationDate = updateCargoOperationDto.OperationDate;
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Cargo Operation updated successfully");
        }
    }
}
