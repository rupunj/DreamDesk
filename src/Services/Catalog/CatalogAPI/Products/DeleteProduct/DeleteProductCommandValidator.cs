using System.Data;
using CatalogAPI.Products.DeleteProduct;

namespace CatalogAPI;

public class DeleteProductCommandValidator :AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x=> x.Id)
            .NotEmpty()
            .WithMessage("Product Id is required");
    }

}
