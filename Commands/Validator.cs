using CQRSDemo.Datastore;
using CQRSDemo.Validation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Commands
{
    /// <summary>
    /// Validator to handle all domain validations 
    /// This does NOT enforce/ensure request is formed correctly, that must be handled in API layer.
    /// </summary>
    // 
    public class Validator : IValidationHandler<AddNoteCommand>
    {
        private readonly DummyRepository repository;

        public Validator(DummyRepository repository) => this.repository = repository;

        public async Task<ValidationResult> Validate(AddNoteCommand request)
        {
            if (repository.NotesItems.Any(x => x.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase)))
                return ValidationResult.Fail("Notes already exists.");

            return ValidationResult.Success;
        }
    }
}
