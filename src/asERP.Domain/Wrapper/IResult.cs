namespace asERP.Domain.Wrapper;

public interface IResult
{
    List<string> Messages { get; set; }

    bool Succeeded { get; set; }

    /// <summary>Outcome of a successful operation.</summary>
    ResultStatus Status { get; set; }

    /// <summary>What went wrong; null on success.</summary>
    Error? Error { get; set; }
}

public interface IResult<out T> : IResult
{
    T Data { get; }
}
