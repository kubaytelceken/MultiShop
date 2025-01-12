using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketTotalAsync(string userId);
        Task saveBasket(BasketTotalDto basketTotalDto);
        Task deleteBasket(string userId);

    }
}
