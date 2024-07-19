namespace CatalogAPI.Products.GetProducts;

public record GetProductRequest(int? PageNumber =2,int? PageSize =1);
public record GetProductResponse(IEnumerable<Product> Products);
public class GetProductsEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetProductQuery>();
            var result = await sender.Send(query);

            var response = result.Adapt<GetProductResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductResponse>(StatusCodes.Status200OK)
        .WithSummary("Get all products")
        .WithDescription("Get all products");
    }
}
