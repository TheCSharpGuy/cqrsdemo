using CQRSDemo.Commands;
using CQRSDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRSDemo.Controllers
{
    [ApiController]
    public class NotesController : Controller
    {
        private readonly IMediator mediator;
        public NotesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetNotesById(int id)
        {
            var response = await mediator.Send(new GetNotesByIdQuery(id));
            return response == null ? NotFound() : Ok(response);
        }
        
        [HttpPost("")]
        public async Task<IActionResult> AddNotes(AddNoteCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
