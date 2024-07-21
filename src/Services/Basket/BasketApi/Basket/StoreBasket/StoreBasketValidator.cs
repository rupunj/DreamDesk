namespace BasketApi.Basket.StoreBasket;

public class StoreBasketValidator:AbstractValidator<StoreBasketCommand>
{
    public StoreBasketValidator()
    {
        RuleFor(x=>x.Cart).NotNull().WithMessage("Cart can not be empty");
        RuleFor(x=>x.Cart.Username).NotNull().WithMessage("Username can not be empty");
    }

}
