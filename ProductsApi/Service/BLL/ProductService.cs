using VoyagerAPI.Service.DAL;

namespace VoyagerAPI.Service.BLL;

public class ProductService : IProductService
{
    /// <summary>
    /// Ussually would be replaced by a EF Core Context.
    /// </summary>
    private readonly FakeDataStore _fakeDataStore;

    public ProductService(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task<List<Product>> GetSomeProducts(CancellationToken cancellationToken)
        => await _fakeDataStore.GetAllProducts(cancellationToken);

    public async Task AddProduct(Product product, CancellationToken cancellationToken)
    {
        await _fakeDataStore.AddProduct(product, cancellationToken);
    }
}