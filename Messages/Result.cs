using FluentValidation.Results;

namespace reflections.Messages;

public class Result<T>
{
    public T Object { get; set; } = default!;
    public ValidationResult ValidationResult { get; set; } = new();

    public bool IsSuccess => ValidationResult.IsValid;

    public string? ErrorMessage => string.Join("; \n", ValidationResult.Errors.Select(x => x.ErrorMessage));
    private Result() { }

    public static Result<T> Success(T obj = default!)
    {
        return new Result<T>()
        {
            Object = obj
        };
    }

    public static Result<T> Return(ValidationResult validationResult)
    {
        return new Result<T>()
        {
            ValidationResult = validationResult
        };
    }

    public static Result<T> Fail(string errorMessage, string errorProperty = "")
    {
        var validationResultWithFail = new ValidationResult()
        {
            Errors =
            {
                new(errorProperty, errorMessage)
            }
        };

        return new Result<T>()
        {
            ValidationResult = validationResultWithFail
        };
    }
}
