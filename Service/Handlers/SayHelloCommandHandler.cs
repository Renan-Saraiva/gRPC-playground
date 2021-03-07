using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Service.Commands;

namespace Service.Handlers
{
    public class SayHelloCommandHandler : IRequestHandler<SayHelloCommand, string>
    {
        private readonly ILogger<SayHelloCommandHandler> _logger;
        private readonly IMediator _mediator;

        public SayHelloCommandHandler(ILogger<SayHelloCommandHandler> logger)
        {
            _logger = logger;           
        }


        public Task<string> Handle(SayHelloCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Receive request. Client={request.Name}. Source={request.Source}");
            return Task.FromResult($"Hello {request.Name} from {request.Source}");
        }
    }
}
