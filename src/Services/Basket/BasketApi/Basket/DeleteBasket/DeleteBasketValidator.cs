namespace BasketApi.Basket.DeleteBasket;

public class DeleteBasketValidator:AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketValidator()
    {
        RuleFor(x=>x.Username).NotNull().WithMessage("Username is required");
    }
}
