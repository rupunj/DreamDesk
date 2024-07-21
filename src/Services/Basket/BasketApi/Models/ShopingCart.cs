namespace BasketApi.Models;

public class ShopingCart
{
    public string Username { get; set; } =default!;
    public List<ShopingCartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quntity) ;

    public ShopingCart(string username)
    {
        Username = username;
    }
    public ShopingCart()
    {
        
    }

}
