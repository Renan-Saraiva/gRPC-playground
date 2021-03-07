using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Commands;
using Service.Dtos;

namespace Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreeterController : Controller
    {
        private readonly IMediator _mediator;

        public GreeterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("say-hello")]
        public async Task<IActionResult> SayHello(HelloRequestDto request)
        {
            return Ok(new HelloResponseDto {
                Message = await _mediator.Send(new SayHelloCommand(request))
            });
        }
    }
}
