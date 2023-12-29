private string GetErrorFromException(Exception exception, string messageTemplate)
        {
                messageTemplate += $"\\nStack Trace: {exception.StackTrace}";
                var innerException = exception.InnerException;
                while (innerException != null)
                {
                    messageTemplate += $"\\nInner Exception: {innerException.Message}";
                    innerException = innerException.InnerException;
                }

                return messageTemplate;
        }
