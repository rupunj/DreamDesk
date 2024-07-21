namespace BasketApi.Models;

public class ShopingCartItem
{
    public int Quntity { get; set; } =default!;
    public string Colour { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public Guid ProductId { get; set; } = default!;
    public string ProductName { get; set; } = default!;

}
