﻿namespace CatalogAPI.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);
internal class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get Product by ID {Query}", query);

        var product = await session.LoadAsync<Product>(query.Id);
        if (product is null)
        {
            throw new ProductnotFoundException(query.Id);
        }


        return new GetProductByIdResult(product);
    }
}
