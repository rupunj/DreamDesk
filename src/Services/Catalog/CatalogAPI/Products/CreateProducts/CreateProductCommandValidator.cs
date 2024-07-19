namespace CatalogAPI.Products.CreateProducts;

public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x=> x.Name)
         .NotEmpty()
         .WithMessage("Name is required");

        RuleFor(x=> x.Catagory)
         .NotEmpty()
         .WithMessage("Category is required");
        
        RuleFor(x=> x.Discription)
         .NotEmpty()
         .WithMessage("Discription is required");

        RuleFor(x=>x.Price)
         .GreaterThan(0)
         .WithMessage("Price Should be greater than zero");

        RuleFor(x=>x.ImageFile)
         .NotEmpty()
         .WithMessage("Image File is required");


    }

}
