namespace CatalogAPI.Products.CreateProducts;

public record CreateProductCommand(string Name,List<string> Catagory,string Discription,string ImageFile,decimal Price ):ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);
public class CreateProductHandler(IDocumentSession documentSession,ILogger<CreateProductHandler> logger) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
      logger.LogInformation("CreateProductHandler called with {@Command}",command);
       var product = new Product
       {
         Name = command.Name,
         Category = command.Catagory,
         Discription = command.Discription,
         ImageFile = command.ImageFile,
         Price = command.Price
       };

       documentSession.Store(product);
       await documentSession.SaveChangesAsync(cancellationToken);

       return new CreateProductResult(product.Id);
    }
}
