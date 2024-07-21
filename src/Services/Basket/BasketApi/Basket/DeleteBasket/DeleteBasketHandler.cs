﻿
namespace BasketApi.Basket.DeleteBasket;

public record DeleteBasketCommand(string Username):ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsSuccess);
public class DeleteBasketCommandHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        await repository.DeleteBasket(command.Username);
        return new DeleteBasketResult(true);
    }
}
