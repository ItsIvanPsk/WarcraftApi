namespace WarcraftApi.Infraestructure.Persistance.Configuration;

public interface IConnectionConfiguration
{
    string ConnectionString { get; }
}