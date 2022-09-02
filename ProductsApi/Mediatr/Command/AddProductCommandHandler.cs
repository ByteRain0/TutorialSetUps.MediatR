using MediatR;
using VoyagerAPI.Mediatr.Publish;
using VoyagerAPI.Service.BLL;
using VoyagerAPI.Service.DAL;

namespace VoyagerAPI.Mediatr.Command;
public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
{
    private readonly IProductService _productService;

    private readonly IMediator _mediator;

    public AddProductCommandHandler(IProductService productService, IMediator mediator)
    {
        _productService = productService;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Id = request.Id,
            Name = request.Name
        };

        await _productService.AddProduct(product, cancellationToken);

        await _mediator.Publish(new ProductAddedNotification()
        {
            Name = request.Name
        });

        return Unit.Value;
    }
}