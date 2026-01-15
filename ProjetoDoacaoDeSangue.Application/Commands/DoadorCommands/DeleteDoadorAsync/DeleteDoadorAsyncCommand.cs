using MediatR;

namespace ProjetoDoacaoDeSangue.Application.Commands.DoadorCommands.DeleteDoadorAsync
{
    public class DeleteDoadorAsyncCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public DeleteDoadorAsyncCommand(int id)
        {
            Id = id;
        }
    }
}
