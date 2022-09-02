using MediatR;
using Voyager.Api;
using VoyagerAPI.Service.DAL;

namespace VoyagerAPI.Mediatr.VoyagerQuery;

[VoyagerRoute(Voyager.Api.HttpMethod.Get, "api/voyager/products")]
public class VoyagerQueryForAllProducts : IRequest<List<Product>>
{
}