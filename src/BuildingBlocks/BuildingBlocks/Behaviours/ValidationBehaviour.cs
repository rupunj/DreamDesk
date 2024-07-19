﻿using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;
namespace BuildingBlocks;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
{
    public async  Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        
        var validationResult = await Task.WhenAll(validators.Select(v=> v.ValidateAsync(context)));
        var failures =
                validationResult
                    .Where(R=> R.Errors.Any())
                    .SelectMany(R=> R.Errors)
                    .ToList();
        
        if(failures.Any())
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}
