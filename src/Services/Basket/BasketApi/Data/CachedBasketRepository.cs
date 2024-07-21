
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace BasketApi.Data;

public class CachedBasketRepository (IBasketRepository repository,IDistributedCache cache): IBasketRepository
{
    public async Task<bool> DeleteBasket(string userName)
    {
       await cache.RemoveAsync(userName);
       return await repository.DeleteBasket(userName);
    }

    public async Task<ShopingCart> GetBasket(string userName)
    {
        var cachedBasket = await cache.GetStringAsync(userName);
        if (!string.IsNullOrWhiteSpace(cachedBasket))
        {
            return JsonSerializer.Deserialize<ShopingCart>(cachedBasket)!;
        }
        var basket = await repository.GetBasket(userName);
        await cache.SetStringAsync(userName,JsonSerializer.Serialize(basket));
        return basket;
    }

    public async Task<ShopingCart> StoreBasket(ShopingCart basket)
    {
        await repository.StoreBasket(basket);
        await cache.SetStringAsync(basket.Username, JsonSerializer.Serialize(basket));
        return basket;
    }
}
