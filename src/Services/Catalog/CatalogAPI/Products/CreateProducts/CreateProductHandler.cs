using BuildingBlocks;

namespace CatalogAPI;

public record CreateProductCommand(string Name,List<string> Catagory,string Discription,string ImageFile,decimal Price ):ICommand<CreateProductResponse>;
public record CreateProductResponse(Guid Id);
public class CreateProductHandler(IDocumentSession documentSession) : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
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

       return new CreateProductResponse(product.Id);
    }
}
