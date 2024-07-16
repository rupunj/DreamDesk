
namespace CatalogAPI.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id ,string Name,List<string> Catagory,string Discription,string ImageFile,decimal Price):ICommand<UpdateProductResult>;

public record UpdateProductResult(bool Success);

internal class UpdateProductHandler(IDocumentSession  documentSession ,ILogger<UpdateProductHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
       logger.LogInformation("UpdateProductHandler.Handle Called with {@Command}", command);

       var product = await documentSession.LoadAsync<Product>(command.Id);
       if (product is null)
       {
           throw new ProductnotFoundException();
       }

       product.Name = command.Name;
       product.Category = command.Catagory;
       product.Discription = command.Discription;
       product.ImageFile = command.ImageFile;
       product.Price = command.Price;
       product.Category = command.Catagory;

       // Update the product in the database
       documentSession.Update(product);
       await documentSession.SaveChangesAsync(cancellationToken);

       return new UpdateProductResult(true);
       
    }
}
