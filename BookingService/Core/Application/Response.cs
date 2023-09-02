namespace Application;
public enum ErrorCodes
{
    NOT_FOUND,
    COULD_NOT_STORE_DATA,
}
public abstract class Response
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
    public ErrorCodes ErrorCode { get; set; }

  
}
