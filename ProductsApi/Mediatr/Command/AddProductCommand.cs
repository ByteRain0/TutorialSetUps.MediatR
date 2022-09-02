using MediatR;

namespace VoyagerAPI.Mediatr.Command;
public class AddProductCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}