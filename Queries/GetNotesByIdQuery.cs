using CQRSDemo.Caching;
using MediatR;
namespace CQRSDemo.Queries
{
    /// <summary>
    /// GetNotesByIdQuery
    /// </summary>
    public record GetNotesByIdQuery(int Id) : IRequest<GetNotesResponse>, ICacheable
    {

        public string CacheKey => $"GetNotesById{Id}";
    }
}
