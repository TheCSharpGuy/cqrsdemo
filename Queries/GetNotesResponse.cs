using CQRSDemo.DTOs;
namespace CQRSDemo.Queries
{
    /// <summary>
    /// The data we are returning
    /// </summary>
    public record GetNotesResponse : BaseResponse
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public bool Completed { get; init; }
    }
}
