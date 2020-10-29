using FluentValidation;
using Homework.Common.Abstract;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework.Common
{

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> 
        where TResponse : SimpleResponse
    {
        private readonly IValidator<TRequest> _validator;
        private readonly ILogger<TRequest> _logger;

        public ValidationBehavior(IValidator<TRequest> validator, ILogger<TRequest> logger)
        {
            _validator = validator;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);

            if (!result.IsValid)
            {
                _logger.LogError($"{nameof(request)}: {result.Errors.Select(s => s.ErrorMessage).Aggregate((acc, curr) => acc += string.Concat("_|_", curr))}");

                var response = new SimpleResponse(result.Errors.Select(s => s.ErrorMessage).ToList());
                return await Task.FromResult(response as TResponse);
            }

            return await next();
        }
    }
}
