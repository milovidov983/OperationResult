public class OperationResult {
    public bool IsSuccess { get; protected set; }
    public string ErrorMessage { get; protected set; }


    protected OperationResult() {
    }

    protected OperationResult(string errorMessage) {
        IsSuccess = false;
        ErrorMessage = errorMessage;
    }

    public static OperationResult Success() {
        return new OperationResult {
            IsSuccess = true
        };
    }

    public static OperationResult Fail(string errorMessage) {
        return new OperationResult(errorMessage);
    }
}

public class OperationResult<T> : OperationResult where T : class {
    public T Value { get; }

    private OperationResult(T value) {
        IsSuccess = true;
        Value = value;
    }


    public static OperationResult<T> Success(T value) {
        return new OperationResult<T>(value);
    }

    public static new OperationResult<T> Fail(string message) {

        return new OperationResult<T>(null) {
            IsSuccess = false,
            ErrorMessage = message
        };
    }
}
