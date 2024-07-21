using BasketApi.Data;

namespace BasketApi.Basket.GetBasket;

public record GetBasketQuery(string Username):IQuery<GetBasketResult>;
public record GetBasketResult(ShopingCart Cart);
public class GetBasketHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
       var basket = await repository.GetBasket(query.Username);
       return new GetBasketResult(basket);
    }
}
