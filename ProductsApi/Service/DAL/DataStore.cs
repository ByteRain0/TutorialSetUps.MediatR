namespace VoyagerAPI.Service.DAL;

/// <summary>
/// Ussualy would be replaced by EF Context.
/// </summary>
public class FakeDataStore
{
    private static List<Product> _products;
    public FakeDataStore()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Test Product 1" },
            new Product { Id = 2, Name = "Test Product 2" },
            new Product { Id = 3, Name = "Test Product 3" }
        };
    }
    public async Task AddProduct(Product product, CancellationToken cancellationToken)
    {
        _products.Add(product);
        await Task.CompletedTask;
    }
    public async Task<List<Product>> GetAllProducts(CancellationToken cancellationToken) => await Task.FromResult(_products);

}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}