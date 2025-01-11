using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.Dto.Dtos.CargoDetailDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {


            CargoDetail cargoCompany = new CargoDetail();
            cargoCompany.SenderCustomer = createCargoDetailDto.SenderCustomer;
            cargoCompany.ReceiverCustomer = createCargoDetailDto.ReceiverCustomer;
            cargoCompany.Barcode = createCargoDetailDto.Barcode;
            cargoCompany.CargoCompanyId = createCargoDetailDto.CargoCompanyId;
            _cargoDetailService.TInsert(cargoCompany);
            return Ok("Cargo Detail created successfully");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Cargo Detail deleted successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoCompany = new CargoDetail();
            cargoCompany.CargoDetailId = updateCargoDetailDto.CargoDetailId;
            cargoCompany.SenderCustomer = updateCargoDetailDto.SenderCustomer;
            cargoCompany.ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer;
            cargoCompany.Barcode = updateCargoDetailDto.Barcode;
            cargoCompany.CargoCompanyId = updateCargoDetailDto.CargoCompanyId;
            _cargoDetailService.TUpdate(cargoCompany);
            return Ok("Cargo Detail updated successfully");
        }
    }
}
