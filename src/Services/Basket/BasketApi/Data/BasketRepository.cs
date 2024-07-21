
using BasketApi.Exceptions;
using Marten;

namespace BasketApi.Data;

public class BasketRepository(IDocumentSession session) : IBasketRepository
{
    public async Task<bool> DeleteBasket(string userName)
    {
        session.Delete<ShopingCart>(userName);
        await session.SaveChangesAsync();
        return true;
    }

    public async Task<ShopingCart> GetBasket(string userName)
    {
        var basket = await session.LoadAsync<ShopingCart>(userName);
        return basket is null ? throw new BasketNotFoundException(userName) :basket;
    }

    public async Task<ShopingCart> StoreBasket(ShopingCart basket)
    {
        session.Store(basket);
        await session.SaveChangesAsync();
        return basket;
    }
}
