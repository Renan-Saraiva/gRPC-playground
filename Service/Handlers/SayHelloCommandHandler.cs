using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Service.Commands;

namespace Service.Handlers
{
    public class SayHelloCommandHandler : IRequestHandler<SayHelloCommand, string>
    {
        public Task<string> Handle(SayHelloCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult($"Hello {request.Name} from {request.Source}");
        }
    }
}
