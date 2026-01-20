using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoDoacaoDeSangue.Application.Commands.DoacaoCommands.CreateDoacaoAsync;
using ProjetoDoacaoDeSangue.Core.Models;

namespace ProjetoDoacaoDeSangue.API.Controllers
{
    [ApiController, Route("api/doacao")]
    public class DoacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDoacaoAsyncCommand model)
        {
            await _mediator.Send(model);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Donation successfully completed!",
                Value = null
            });
        }
    }
}
