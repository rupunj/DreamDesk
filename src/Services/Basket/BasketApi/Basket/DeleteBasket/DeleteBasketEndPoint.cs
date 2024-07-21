
namespace BasketApi.Basket.DeleteBasket;

public record DeleteBasketRequest(string Username);

public class DeleteBasketResponse(bool IsSuccess);
public class DeleteBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{username}",async (string username, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(username));
            var response = result.Adapt<DeleteBasketResponse>();
            return Results.Ok(response);

        })
        .WithName("DeleteBasket")
        .WithDescription("Delete Basket By UserName")
        .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Basket By UserName");
    }
}
