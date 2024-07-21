namespace BasketApi.Data;

public interface IBasketRepository
{
    Task<ShopingCart> GetBasket(string userName);
    Task<ShopingCart> StoreBasket(ShopingCart basket);
    Task<bool> DeleteBasket(string userName);

}
