namespace BasketApi.Basket.GetBasket;

public record GetBasketQuery(string Username):IQuery<GetBasketResult>;
public record GetBasketResult(ShopingCart Cart);
public class GetBasketHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
       //TODO: get basket result from database
       return new GetBasketResult(new ShopingCart("shop"));
    }
}
