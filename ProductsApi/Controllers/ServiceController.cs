using Microsoft.AspNetCore.Mvc;
using VoyagerAPI.Service.BLL;
using VoyagerAPI.Service.DAL;

namespace VoyagerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Products : ControllerBase
{
    private readonly IProductService _someService;

    public Products(IProductService someService)
    {
        _someService = someService;
    }

    [HttpGet]
    public async Task<List<Product>> List(CancellationToken cancellationToken)
        => await _someService.GetSomeProducts(cancellationToken);

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Product product, CancellationToken cancellationToken)
    {
        await _someService.AddProduct(product, cancellationToken);
        return new OkResult();
    }
}