namespace CatalogAPI.Products.GetProductsByCatagory;

public record GetProductsByCatagoryResquest(string catagory) : IQuery<GetProductsByCatagoryResult>;
public record GetProductsByCatagoryResult(IEnumerable<Product> Products);
internal class GetProductsByCatagoryHandler(IDocumentSession session, ILogger<GetProductsByCatagoryHandler> logger) : IQueryHandler<GetProductsByCatagoryResquest, GetProductsByCatagoryResult>
{
    public async Task<GetProductsByCatagoryResult> Handle(GetProductsByCatagoryResquest query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get Products By Catagory {Query}", query);
        var result = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.catagory))
            .ToListAsync();

        return new GetProductsByCatagoryResult(result);
    }
}
