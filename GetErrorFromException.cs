private static string GetErrorFromException(Exception exception, string messageTemplate)
{
    StringBuilder stringBuilder = new StringBuilder(messageTemplate);
    stringBuilder.AppendLine($"Stack Trace: {exception.StackTrace}");

    var innerException = exception.InnerException;
    while (innerException != null)
    {
        stringBuilder.AppendLine($"Inner Exception: {innerException.Message}");
        innerException = innerException.InnerException;
    }

    return stringBuilder.ToString();
}
