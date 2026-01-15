using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.CreateDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.DeleteDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.UpdateDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetAllDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetByIdDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetDonationHistoryAsync;

namespace ProjetoDoacaoDeSangue.API.Controllers
{
    [ApiController, Route("api/doador")]
    public class DoadorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoadorAsync([FromBody] CreateDoadorAsyncCommand model)
        {
            var id = await _mediator.Send(model);
            return Ok(id);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteDoadorAsync(int id)
        {
            var command = new DeleteDoadorAsyncCommand(id);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> UpdateDoadorAsync([FromBody] UpdateDoadorAsyncCommand model)
        {
            await _mediator.Send(model);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoadorAsync()
        {
            var query = new GetAllDoadorAsyncQuery();
            var doadores = await _mediator.Send(query);

            return Ok(doadores);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdDoadorAsync(int id)
        {
            var query = new GetByIdDoadorAsyncQuery(id);
            var doador = await _mediator.Send(query);

            return Ok(doador);
        }

        [HttpGet, Route("{id}/history")]
        public async Task<IActionResult> GetDonationHistoryAsync(int id)
        {
            var query = new GetDonationHistoryAsyncQuery(id);
            var doacoes = await _mediator.Send(query);

            return Ok(doacoes);
        }
    }
}
