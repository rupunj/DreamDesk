
namespace BasketApi.Basket.DeleteBasket;

public record DeleteBasketCommand(string Username):ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsSuccess);
public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
