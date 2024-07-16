namespace CatalogAPI.Exceptions;

public class ProductnotFoundException : Exception
{
    public ProductnotFoundException() : base("Product not found")
    {
    }
}
