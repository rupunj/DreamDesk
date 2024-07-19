﻿using System.Reflection.Metadata;

namespace CatalogAPI.Products.GetProducts;

public record GetProductQuery() : IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<Product> Products);
public class GetProductsHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var Products = await session.Query<Product>().ToListAsync();
        return new GetProductResult(Products);
    }
}
