public static HttpRequestMessage ToHttpRequestMessage<T>(this T request, string url, HttpMethod method, Dictionary<string, string> headers = null)
{
    if (request == null)
        throw new ArgumentNullException(nameof(request));

    if (string.IsNullOrWhiteSpace(url))
        throw new ArgumentException("URL cannot be null or whitespace.", nameof(url));

    var result = new HttpRequestMessage(method, url)
    {
        Content = new StringContent(JsonConvert.SerializeObject(request, Formatting.None), Encoding.UTF8, "application/json")
    };

    headers ??= [];

    foreach (var header in headers)
    {
        result.Headers.TryAddWithoutValidation(header.Key, header.Value);
    }

    return result;
}
