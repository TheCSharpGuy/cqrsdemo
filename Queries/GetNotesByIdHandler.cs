using CQRSDemo.Datastore;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace CQRSDemo.Queries
{
    /// <summary>
    /// Perform the business logic to execute. Returns a response 
    /// </summary>
    public class GetNotesByIdHandler : IRequestHandler<GetNotesByIdQuery, GetNotesResponse>
    {
        private readonly DummyRepository repository;

        public GetNotesByIdHandler(DummyRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetNotesResponse> Handle(GetNotesByIdQuery request, CancellationToken cancellationToken)
        {
            var note = repository.NotesItems.FirstOrDefault(x => x.Id == request.Id);
            return note == null ? null : new GetNotesResponse { Id = note.Id, Name = note.Name, Completed = note.Completed };
        }
    }
}
