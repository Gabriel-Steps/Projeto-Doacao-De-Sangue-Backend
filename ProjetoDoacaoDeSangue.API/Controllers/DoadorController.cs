using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.CreateDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.DeleteDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.UpdateDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetAllDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetByIdDoadorAsync;
using ProjetoDoacaoDeSangue.Application.Queries.DoadoresQuerys.GetDonationHistoryAsync;
using ProjetoDoacaoDeSangue.Core.Models;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Application.ViewModels.DoadorViewModels;

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
            return Ok(new ApiResponse<int>
            {
                Status = true,
                Message = null,
                Value = id
            });
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteDoadorAsync(int id)
        {
            var command = new DeleteDoadorAsyncCommand(id);
            await _mediator.Send(command);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Donor successfully deleted!",
                Value = null
            });
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> UpdateDoadorAsync([FromBody] UpdateDoadorAsyncCommand model)
        {
            await _mediator.Send(model);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = "Donor successfully updated!",
                Value = null
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoadorAsync()
        {
            var query = new GetAllDoadorAsyncQuery();
            var doadores = await _mediator.Send(query);

            return Ok(new ApiResponse<List<Doador>>
            {
                Status = true,
                Message = null,
                Value = doadores
            });
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetByIdDoadorAsync(int id)
        {
            var query = new GetByIdDoadorAsyncQuery(id);
            var doador = await _mediator.Send(query);

            return Ok(new ApiResponse<GetDataDoadorViewDto>
            {
                Status = true,
                Message = null,
                Value = doador
            });
        }

        [HttpGet, Route("{id}/history")]
        public async Task<IActionResult> GetDonationHistoryAsync(int id)
        {
            var query = new GetDonationHistoryAsyncQuery(id);
            var doacoes = await _mediator.Send(query);

            return Ok(new ApiResponse<List<Doacao>>
            {
                Status = true,
                Message = null,
                Value = doacoes
            });
        }
    }
}
