using System.Net;

namespace CQRSDemo.DTOs
{
    public record BaseResponse
    {
        public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
        public string ErrorMessage { get; init; }
    }
}
