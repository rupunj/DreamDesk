
namespace CatalogAPI;
public record GetProductResponse (IEnumerable<Product> Products);
public class GetProductsEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products",async(ISender sender) =>
        {
            var result = await sender.Send(new GetProductQuery());

            var response = result.Adapt<GetProductResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductResponse>(StatusCodes.Status200OK)
        .WithSummary("Get all products")
        .WithDescription("Get all products");
    }
}
