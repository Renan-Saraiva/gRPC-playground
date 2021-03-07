using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using Service.Commands;

namespace Service
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IMediator _mediator;

        public GreeterService(ILogger<GreeterService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public override async Task<HelloResponse> SayHello(HelloRequest request, ServerCallContext context)
        {
            return new HelloResponse
            {
                Message = await _mediator.Send(new SayHelloCommand(request))
            };
        }
    }
}

