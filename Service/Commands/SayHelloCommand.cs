using MediatR;
using Service.Dtos;

namespace Service.Commands
{
    public class SayHelloCommand : IRequest<string>
    {
        public string Name { get; private set; }
        public string Source { get; private set; }

        public SayHelloCommand(HelloRequestDto request)
        {
            Name = request.Name;
            Source = "API";
        }

        public SayHelloCommand(Proto.Library.HelloRequest request)
        {
            Name = request.Name;
            Source = "gRPC";
        }
    }
}
