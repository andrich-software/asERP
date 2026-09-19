namespace asERP.Domain.Wrapper;

/// <summary>
/// A result is built once and never changed afterwards — every property is init-only and the
/// messages are read-only. Produce one through the factories on <see cref="Result"/> /
/// <see cref="Result{T}"/> rather than assembling it field by field.
/// </summary>
public interface IResult
{
    IReadOnlyList<string> Messages { get; init; }

    bool Succeeded { get; init; }

    /// <summary>Outcome of a successful operation.</summary>
    ResultStatus Status { get; init; }

    /// <summary>What went wrong; null on success.</summary>
    Error? Error { get; init; }
}

public interface IResult<out T> : IResult
{
    T Data { get; }
}
