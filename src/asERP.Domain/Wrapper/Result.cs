#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.Text.Json.Serialization;

namespace asERP.Domain.Wrapper;

/// <summary>
/// Class to represent a result from APIs or services
/// Can return success or fail results with an optional data
/// </summary>
public class Result : IResult
{
    public List<string> Messages { get; set; } = [];

    public bool Succeeded { get; set; }

    /// <summary>
    /// Outcome of a successful operation. Failures leave this at <see cref="ResultStatus.Ok"/> and
    /// describe themselves through <see cref="Error"/>.
    /// </summary>
    public ResultStatus Status { get; set; } = ResultStatus.Ok;

    /// <summary>
    /// What went wrong, for results produced through the semantic factories. Null on success.
    /// </summary>
    public Error? Error { get; set; }

    /// <summary>
    /// Marks this result as failed with a semantic error. Replaces the three-line
    /// <c>Succeeded</c>/<c>StatusCode</c>/<c>Messages.Add</c> dance so handlers never name an HTTP
    /// status.
    /// </summary>
    /// <param name="type">Kind of failure — the Server turns this into an HTTP status.</param>
    /// <param name="code">Stable code from <see cref="ErrorCodes"/>.</param>
    /// <param name="message">Developer-facing English fallback text.</param>
    public void Fail(ErrorType type, string code, string message)
    {
        Succeeded = false;
        Error = new Error(type, code, message);
        Messages.Add(message);
    }

    /// <summary>
    /// Marks this result as failed without adding a message — for the cases where the detail is a
    /// list the caller appends itself (Identity errors, per-row import failures). The code still
    /// tells a client what kind of failure this is.
    /// </summary>
    public void Fail(ErrorType type, string code)
    {
        Succeeded = false;
        Error = new Error(type, code, string.Empty);
    }

    // ---- semantic results (preferred) --------------------------------------------------

    public static Result Failure(Error error) => new()
    {
        Succeeded = false,
        Error = error,
        Messages = [error.Message]
    };

    public static Result Invalid(string code, string message) =>
        Failure(new Error(ErrorType.Validation, code, message));

    public static Result NotFound(string code, string message) =>
        Failure(new Error(ErrorType.NotFound, code, message));

    public static Result Conflict(string code, string message) =>
        Failure(new Error(ErrorType.Conflict, code, message));

    public static Result Unauthorized(string code, string message) =>
        Failure(new Error(ErrorType.Unauthorized, code, message));

    public static Result Forbidden(string code, string message) =>
        Failure(new Error(ErrorType.Forbidden, code, message));

    public static Result Unexpected(string code, string message) =>
        Failure(new Error(ErrorType.Unexpected, code, message));

    public static Result Ok() => new() { Succeeded = true, Status = ResultStatus.Ok };

    public static Result NoContent() => new()
    {
        Succeeded = true,
        Status = ResultStatus.NoContent
    };

    public static IResult Fail()
    {
        return new Result { Succeeded = false };
    }

    public static IResult Fail(string message)
    {
        return new Result { Succeeded = false, Messages = new List<string> { message } };
    }

    public static IResult Fail(List<string> messages)
    {
        return new Result { Succeeded = false, Messages = messages };
    }

    public static Task<IResult> FailAsync()
    {
        return Task.FromResult(Fail());
    }

    public static Task<IResult> FailAsync(string message)
    {
        return Task.FromResult(Fail(message));
    }

    public static Task<IResult> FailAsync(List<string> messages)
    {
        return Task.FromResult(Fail(messages));
    }

    public static IResult Success()
    {
        return new Result { Succeeded = true };
    }

    public static IResult Success(string message)
    {
        return new Result { Succeeded = true, Messages = new List<string> { message } };
    }

    public static Task<IResult> SuccessAsync()
    {
        return Task.FromResult(Success());
    }

    public static Task<IResult> SuccessAsync(string message)
    {
        return Task.FromResult(Success(message));
    }
}

public class Result<T> : Result, IResult<T>
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public T Data { get; set; }

    // ---- semantic results (preferred) --------------------------------------------------
    // Handlers describe *what* happened; the Server decides which HTTP status that becomes.

    public new static Result<T> Failure(Error error) => new()
    {
        Succeeded = false,
        Error = error,
        Messages = [error.Message]
    };

    public new static Result<T> Invalid(string code, string message) =>
        Failure(new Error(ErrorType.Validation, code, message));

    public new static Result<T> NotFound(string code, string message) =>
        Failure(new Error(ErrorType.NotFound, code, message));

    public new static Result<T> Conflict(string code, string message) =>
        Failure(new Error(ErrorType.Conflict, code, message));

    public new static Result<T> Unauthorized(string code, string message) =>
        Failure(new Error(ErrorType.Unauthorized, code, message));

    public new static Result<T> Forbidden(string code, string message) =>
        Failure(new Error(ErrorType.Forbidden, code, message));

    public new static Result<T> Unexpected(string code, string message) =>
        Failure(new Error(ErrorType.Unexpected, code, message));

    public static Result<T> Ok(T data) => new()
    {
        Succeeded = true,
        Data = data,
        Status = ResultStatus.Ok
    };

    public static Result<T> Created(T data) => new()
    {
        Succeeded = true,
        Data = data,
        Status = ResultStatus.Created
    };

    public new static Result<T> NoContent() => new()
    {
        Succeeded = true,
        Status = ResultStatus.NoContent
    };

    public new static Result<T> Fail()
    {
        return new Result<T> { Succeeded = false };
    }

    public new static Result<T> Fail(string message)
    {
        return new Result<T> { Succeeded = false, Messages = new List<string> { message } };
    }

    public new static Result<T> Fail(List<string> messages)
    {
        return new Result<T> { Succeeded = false, Messages = messages };
    }

    // ReSharper disable once UnusedMember.Global
    public new static Task<Result<T>> FailAsync()
    {
        return Task.FromResult(Fail());
    }

    // ReSharper disable once UnusedMember.Global
    public new static Task<Result<T>> FailAsync(string message)
    {
        return Task.FromResult(Fail(message));
    }

    public new static Task<Result<T>> FailAsync(List<string> messages)
    {
        return Task.FromResult(Fail(messages));
    }

    public new static Result<T> Success()
    {
        return new Result<T> { Succeeded = true };
    }

    public new static Result<T> Success(string message)
    {
        return new Result<T> { Succeeded = true, Messages = new List<string> { message } };
    }

    public static Result<T> Success(T data)
    {
        return new Result<T> { Succeeded = true, Data = data };
    }

    public static Result<T> Success(T data, string message)
    {
        return new Result<T> { Succeeded = true, Data = data, Messages = new List<string> { message } };
    }

    public static Result<T> Success(T data, List<string> messages)
    {
        return new Result<T> { Succeeded = true, Data = data, Messages = messages };
    }

    public new static Task<Result<T>> SuccessAsync()
    {
        return Task.FromResult(Success());
    }

    public new static Task<Result<T>> SuccessAsync(string message)
    {
        return Task.FromResult(Success(message));
    }

    public static Task<Result<T>> SuccessAsync(T data)
    {
        return Task.FromResult(Success(data));
    }

    public static Task<Result<T>> SuccessAsync(T data, string message)
    {
        return Task.FromResult(Success(data, message));
    }

    public static Task<Result<T>> SuccessAsync(T data, List<string> messages)
    {
        return Task.FromResult(new Result<T> { Succeeded = true, Data = data, Messages = messages });
    }
}
