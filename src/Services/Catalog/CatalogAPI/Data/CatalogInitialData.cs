using Marten.Schema;

namespace CatalogAPI.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session =store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return ;
        
        session.Store<Product>(GetPreConfiguredProducts());
        await session.SaveChangesAsync();
    }

    private IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>
    {
       new Product()
        {
            Id = Guid.NewGuid(),
            Name = "IPhone X",
            Discription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            ImageFile = "product-1.png",
            Price = 950,
            Category =new List<string> {"Smart Phone"}
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Samsung 10",
            Discription = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            ImageFile = "product-2.png",
            Price = 840,
            Category =new List<string> {"Smart Phone"}
        }
    };
}
  
