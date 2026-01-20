using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoDoacaoDeSangue.Application.Commands.EstoqueSangueCommands.UpsertEstoqueSangueAsync;
using ProjetoDoacaoDeSangue.Application.Queries.EstoqueSangueQuerys.GetByTypeBloodAsync;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Core.Models;

namespace ProjetoDoacaoDeSangue.API.Controllers
{
    [ApiController, Route("api/estoque-sangue")]
    public class EstoqueSangueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstoqueSangueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UpsertAsync([FromBody] UpsertEstoqueSangueAsyncCommand model)
        {
            await _mediator.Send(model);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Blood inventory update was successfully completed!",
                Value = null
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllEstoqueSangueAsyncQuery();
            var estoqueSangue = await _mediator.Send(query);
            return Ok(new ApiResponse<List<EstoqueSangue>>
            {
                Status = true,
                Message = null,
                Value = estoqueSangue
            });
        }
    }
}
