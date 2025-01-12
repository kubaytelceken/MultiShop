using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }


        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var user = User.Claims;
            var values = _basketService.GetBasketTotalAsync(_loginService.GetUserId);
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.saveBasket(basketTotalDto);
            return Ok("The Basket saved.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.deleteBasket(_loginService.GetUserId);
            return Ok("The Basket deleted.");
        }
    }
}
