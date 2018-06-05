public class OperationResult
{
    protected OperationResult(string errorMessage)
    {
        IsSuccess = false;
        ErrorMessage = errorMessage;
    }

    protected OperationResult()
    {
    }

    public bool IsSuccess { get; protected set; }

    public string ErrorMessage { get; protected set; }

    public static OperationResult Success()
    {
        return new OperationResult
        {
            IsSuccess = true
        };
    }

    public static OperationResult Fail(string errorMessage)
    {
        return new OperationResult(errorMessage);
    }
}

public class OperationResult<T> : OperationResult
    where T : class
{
    private OperationResult(T model)
    {
        IsSuccess = true;
        Model = model;
    }

    public T Model { get; }

    public static OperationResult<T> Success(T model)
    {
        return new OperationResult<T>(model);
    }

    public static new OperationResult<T> Fail(string message)
    {
        return new OperationResult<T>(null)
        {
            IsSuccess = false,
            ErrorMessage = message
        };
    }
}
