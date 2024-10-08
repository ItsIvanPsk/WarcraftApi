using Microsoft.Extensions.Configuration;

namespace WarcraftApi.Infraestructure.Persistance.Configuration;

public class ConnectionConfiguration : IConnectionConfiguration
{
    private readonly IConfiguration _configuration;

    public ConnectionConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string ConnectionString => _configuration.GetConnectionString("SQLDatabase");

}