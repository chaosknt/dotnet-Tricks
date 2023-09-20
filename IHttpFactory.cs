1- 

  public static class HttpClientsConfigurationExtension
{
    public static IServiceCollection HttpClientsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var expedicionApiSceBaseUrl = configuration.GetValue<string>("ConfigurationExpedicionApiSce:BaseUrl");

        services.AddHttpClient("ExpedicionApiSce", client =>
        {
            client.BaseAddress = new System.Uri(expedicionApiSceBaseUrl);
        });

        return services;
    }
}

2- builder.Services.HttpClientsConfiguration(builder.Configuration); (deberia ir en la capa de aplicacion

3- 

    private readonly HttpClient _httpClient;
    public ExpedicionApiSceService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ExpedicionApiSce");
    }

    public async Task SomeMethod()
    {
      _httpClient.SendAsync();
    }
//https://www.youtube.com/watch?v=Z6Y2adsMnAA&t=2s&ab_channel=NickChapsas

                                                                      
