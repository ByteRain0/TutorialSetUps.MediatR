using MediatR;
using VoyagerAPI.Service.BLL;
using VoyagerAPI.Service.DAL;

namespace VoyagerAPI.Mediatr.Query;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<Product>>
{
    private readonly IProductService _productService;

    public GetProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<List<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetSomeProducts(cancellationToken);
    }
}