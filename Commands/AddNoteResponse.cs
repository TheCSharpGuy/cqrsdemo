using CQRSDemo.DTOs;

namespace CQRSDemo.Commands
{
    /// <summary>
    /// AddNoteResponse
    /// </summary>
    public record AddNoteResponse : BaseResponse
    {
        public int Id { get; init; }
    }
}
