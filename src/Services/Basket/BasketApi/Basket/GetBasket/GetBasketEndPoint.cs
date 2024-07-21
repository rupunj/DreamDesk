
namespace BasketApi.Basket.GetBasket;

public record GetBasketResponse(ShopingCart Cart);
public class GetBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       app.MapGet("/basket/{username}",async(string username ,ISender sender)=>
       {
            var result = await sender.Send(new GetBasketQuery(username));
            var response = result.Adapt<GetBasketResponse>();
            return Results.Ok(response);

       })
       .WithName("GetBasket")
       .WithDescription("Get Basket By UserName")
       .Produces<GetBasketResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Get Basket By UserName");
    }
}
