﻿
namespace CatalogAPI.Products.CreateProducts;

public record CreateProductRequest(string Name,List<string> Catagory,string Discription,string ImageFile,decimal Price );
public record CreateProductResponse(Guid Id);

public class CreateProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",async(CreateProductRequest request ,ISender sender) =>
        {
            var command= request.Adapt<CreateProductCommand>();
            var result = await sender.Send(command);
            var response  = result.Adapt<CreateProductResponse>();

            return Results.Created($"/products/{response.Id}",result);
        })
        .WithName("CreatedProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Crated product")
        .WithDescription("Created product");
    }
}
