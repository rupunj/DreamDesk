

namespace BasketApi.Basket.StoreBasket;

public record StoreBasketCommand(ShopingCart Cart):ICommand<StoreBasketResult>;
public record StoreBasketResult(string Username);
public class StoreBasketCommandHandler(IBasketRepository repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        await repository.StoreBasket(command.Cart);
        //TODO:update cache

        return new StoreBasketResult(command.Cart.Username);
    }
}
