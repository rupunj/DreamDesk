
namespace BasketApi.Basket.StoreBasket;

public record StoreBasketCommand(ShopingCart Cart):ICommand<StoreBasketResult>;
public record StoreBasketResult(string username);
public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShopingCart cart = command.Cart;
        //TODO: save basket to database (Use matren upsert - if exsist = update if not insert)
        //TODO:update cache

        return new StoreBasketResult("swn");
    }
}
