using CQRSDemo.DTOs;
using CQRSDemo.Validation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSDemo.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : BaseResponse, new()
    {
        private readonly ILogger<ValidationBehaviour<TRequest, TResponse>> logger;
        private readonly IValidationHandler<TRequest> validationHandler;

        /// <summary>
        /// Safety net : Keeping 2 constructors to handle the scenarios where validator does not exist
        /// </summary>

        public ValidationBehaviour(ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        public ValidationBehaviour(ILogger<ValidationBehaviour<TRequest, TResponse>> logger, IValidationHandler<TRequest> validationHandler)
        {
            this.logger = logger;
            this.validationHandler = validationHandler;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType();
            if (validationHandler == null)
            {
                logger.LogInformation($"{requestName} does not have a validation handler configured.");
                return await next();
            }

            var result = await validationHandler.Validate(request);
            if (!result.IsSuccessful)
            {
                logger.LogWarning($"Validation failed for {requestName}. Error: {result.Error}");
                return new TResponse { StatusCode = HttpStatusCode.BadRequest, ErrorMessage = result.Error };
            }

            logger.LogInformation($"Validation successful for {requestName}.");
            return await next();
        }
    }
}
