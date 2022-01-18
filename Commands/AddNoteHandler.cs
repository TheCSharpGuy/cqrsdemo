using CQRSDemo.Datastore;
using CQRSDemo.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSDemo.Commands
{
    /// <summary>
    /// AddNoteHandler
    /// </summary>
    public class AddNoteHandler : IRequestHandler<AddNoteCommand, AddNoteResponse>
    {
        private readonly DummyRepository repository;

        public AddNoteHandler(DummyRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AddNoteResponse> Handle(AddNoteCommand request, CancellationToken cancellationToken)
        {
            repository.NotesItems.Add(new Notes { Id = 10, Name = request.Name });
            return new AddNoteResponse { Id = 10 };
        }
    }
}
