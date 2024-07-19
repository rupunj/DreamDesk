namespace CatalogAPI.Exceptions;

public class ProductnotFoundException : NotFoundException
{
    public ProductnotFoundException(Guid Id) : base("Product", Id)
    {
    }
}
