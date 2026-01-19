using MediatR;

namespace ProjetoDoacaoDeSangue.Application.Commands.EnderecoCommands.CreateEnderecoAsync
{
    public class CreateEnderecoAsyncCommand : IRequest<Unit>
    {
        public int DoadorId { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
    }
}
