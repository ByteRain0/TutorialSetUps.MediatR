using MediatR;
using VoyagerAPI.Service.DAL;

namespace VoyagerAPI.Mediatr.Query;

public class GetProductQuery : IRequest<List<Product>>
{
}