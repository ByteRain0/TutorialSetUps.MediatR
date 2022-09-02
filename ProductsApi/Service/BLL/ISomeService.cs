using VoyagerAPI.Service.DAL;

namespace VoyagerAPI.Service.BLL;

public interface IProductService
{
    Task AddProduct(Product product, CancellationToken cancellationToken);
    Task<List<Product>> GetSomeProducts(CancellationToken cancellationToken);
}
