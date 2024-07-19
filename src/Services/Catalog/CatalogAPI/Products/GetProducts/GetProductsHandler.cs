﻿using System.Reflection.Metadata;
using Marten.Pagination;

namespace CatalogAPI.Products.GetProducts;

public record GetProductQuery(int? PageNumber =2,int? PageSize =1) : IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<Product> Products);
public class GetProductsHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var Products = await session.Query<Product>().ToPagedListAsync(query.PageNumber?? 1, query.PageSize ?? 1);
        return new GetProductResult(Products);
    }
}
