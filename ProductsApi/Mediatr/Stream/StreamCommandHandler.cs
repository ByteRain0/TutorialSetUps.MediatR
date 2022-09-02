using MediatR;

namespace VoyagerAPI.Mediatr.Stream;
public class StreamCommandHandler : IStreamRequestHandler<StreamCommand, string>
{
    public async IAsyncEnumerable<string> Handle(StreamCommand request, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(1000, cancellationToken);
            yield return (new Random()).Next(100).ToString();
        }
    }
}
