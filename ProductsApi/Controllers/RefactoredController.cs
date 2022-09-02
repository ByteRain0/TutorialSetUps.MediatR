using MediatR;
using Microsoft.AspNetCore.Mvc;
using VoyagerAPI.Mediatr.Command;
using VoyagerAPI.Mediatr.Query;
using VoyagerAPI.Mediatr.Stream;
using VoyagerAPI.Service.DAL;

namespace VoyagerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RefactoredController : ControllerBase
{
    private readonly IMediator _mediator;

    public RefactoredController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Product>> List(GetProductQuery query, CancellationToken cancellationToken)
        => await _mediator.Send(query, cancellationToken);

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProductCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return new OkResult();
    }

    [HttpGet("random")]
    public IAsyncEnumerable<string> GetRandomNumbers(CancellationToken cancellationToken)
        => _mediator.CreateStream(new StreamCommand(), cancellationToken);
}
