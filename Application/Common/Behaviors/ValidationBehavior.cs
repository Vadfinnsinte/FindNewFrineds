using Application.Common;
using FluentValidation;
using MediatR;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(
        IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .Select(f => f.ErrorMessage)
                .ToList();

            if (failures.Any())
            {
                var responseType = typeof(TResponse);

                if (responseType.IsGenericType &&
                    responseType.GetGenericTypeDefinition() == typeof(OperationResult<>))
                {
                    var innerType = responseType.GetGenericArguments()[0];

                    var resultType =
                        typeof(OperationResult<>).MakeGenericType(innerType);

                    var failureMethod =
                        resultType.GetMethod(nameof(OperationResult<object>.Failure));

                    var failureResult =
                        failureMethod?.Invoke(null, new object[] { failures.ToArray() });

                    return (TResponse)failureResult!;
                }
            }
        }

        return await next();
    }
}