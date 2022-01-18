using CQRSDemo.Entity;
using System.Collections.Generic;

namespace CQRSDemo.Datastore
{
    public class DummyRepository
    {
        public List<Notes> NotesItems { get; } = new List<Notes>
        {
            new Notes{Id = 1, Name = "Call xyz", Completed = false },
            new Notes{Id = 2, Name = "Inform CQRS is fun!", Completed = true },
            new Notes{Id = 3, Name = "Create blog for demo code", Completed = false },
            new Notes{Id = 4, Name = "Share the code", Completed = true },
        };
    }
}
