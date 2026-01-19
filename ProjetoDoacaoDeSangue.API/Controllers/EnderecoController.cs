using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoDoacaoDeSangue.Application.Commands.EnderecoCommands.CreateEnderecoAsync;
using ProjetoDoacaoDeSangue.Application.Queries.EnderecoQuerys.GetByIdDoadorEnderecoAsync;
using ProjetoDoacaoDeSangue.Application.Queries.EnderecoQuerys.GetEnderecoByCepAsync;
using ProjetoDoacaoDeSangue.Core.Entities;
using ProjetoDoacaoDeSangue.Core.Models;
using ProjetoDoacaoDeSangue.Infra.Models.EnderecoModels;

namespace ProjetoDoacaoDeSangue.API.Controllers
{
    [Route("api/endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnderecoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("cep/{cep}")]
        public async Task<IActionResult> GetByCep(string cep)
        {
            var query = new GetEnderecoByCepQuery(cep);
            var endereco = await _mediator.Send(query);

            return Ok(new ApiResponse<EnderecoViaCepDto>
            {
                Status = true,
                Message = null,
                Value = endereco
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEnderecoAsyncCommand model)
        {
            await _mediator.Send(model);
            return Ok(new ApiResponse<object>
            {
                Status = true,
                Message = null,
                Value = null
            });
        }

        [HttpGet, Route("address-donor/{id}")]
        public async Task<IActionResult> GetByIdDonorAddress(int id)
        {
            var query = new GetByIdDoadorEnderecoAsyncQuery(id);
            var endereco = await _mediator.Send(query);

            return Ok(new ApiResponse<Endereco>
            {
                Status = true,
                Message = null,
                Value = endereco
            });
        }
    }
}
