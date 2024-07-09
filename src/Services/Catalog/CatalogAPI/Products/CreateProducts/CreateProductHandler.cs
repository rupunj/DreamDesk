using BuildingBlocks;

namespace CatalogAPI;

public record CreateProductCommand(string Name,List<string> Catagory,string Discription,string ImageFile,decimal Price ):ICommand<CreateProductResponse>;
public record CreateProductResponse(Guid Id);
public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    public Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
