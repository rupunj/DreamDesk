﻿
namespace CatalogAPI.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id):ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);
internal class DeleteProductHandler(IDocumentSession session,ILogger<DeleteProductHandler> logger) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Delete Product Command {request}",request);
        
        session.Delete<Product>(request.Id);
        await session.SaveChangesAsync(cancellationToken);
        
        return new DeleteProductResult(true);

    }
}
