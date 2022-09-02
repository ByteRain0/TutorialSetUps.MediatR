using MediatR;
using VoyagerAPI.Service.DAL;

namespace VoyagerAPI.Mediatr.VoyagerQuery;

public class VoyagerQueryForAllProductsHandler : IRequestHandler<VoyagerQueryForAllProducts, List<Product>>
{
    private readonly FakeDataStore _fakeDataStore;

    public VoyagerQueryForAllProductsHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task<List<Product>> Handle(VoyagerQueryForAllProducts request, CancellationToken cancellationToken)
    {
        return await _fakeDataStore.GetAllProducts(cancellationToken);
    }
}
