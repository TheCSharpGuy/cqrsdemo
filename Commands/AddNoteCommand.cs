using MediatR;

namespace CQRSDemo.Commands
{
    public record AddNoteCommand(string Name) : IRequest<AddNoteResponse>;
}
