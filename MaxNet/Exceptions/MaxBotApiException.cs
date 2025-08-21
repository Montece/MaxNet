namespace MaxNet.Exceptions;

public sealed class MaxBotApiException : Exception
{
    public int StatusCode { get; }
    public string? ErrorCode { get; }

    public MaxBotApiException(int statusCode, string? errorCode, string message) : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
}