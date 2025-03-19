--Para consumir DataAccessAwsPostGresql

Criar um arquivo "appsettings.json" no projeto 
```json
{
  "Region": "sa-xxxx-1",
  "SecretsManager": {
    "PortNumber": 5432,
    "HostName": "xxxx",
    "Username": "xxxx",
    "Password": "xxxx"
  }
}
```

criar uma classe
```csharp
public class DependencyInjection
{
    internal static IServiceProvider ResolveDependencies()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Define o diretório base
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Carrega o JSON
            .Build();
        var services = new ServiceCollection();

        #region Variacel de ambiente - Entidade pertence a "using DataAccessAwsPostGresql.Entidade"
        services.Configure<Settings>(opt =>
        {
            opt.Port = int.Parse(configuration.GetSection("SecretsManager:PortNumber").Value);
            opt.DataBase = configuration.GetSection("SecretsManager:DataBase").Value;
            opt.HostName = configuration.GetSection("SecretsManager:HostName").Value;
            opt.UsersSecretName = configuration.GetSection("SecretsManager:Username").Value;
            opt.PwdSecretName = configuration.GetSection("SecretsManager:Password").Value;
            opt.Environment = "local";
        });
        #endregion

        #region Implementar conexão "DataAccessAwsPostGresql"
        services.AddTransient<DbConexaoService>();
        services.AddScoped<IDbConexaoService, DbConexaoService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAmazonSecretsManager, AmazonSecretsManagerClient>();
        services.AddScoped<ISecretCache, SecretsManagerFacade>();
        #endregion
        return services.BuildServiceProvider(); 
    }
}
```
Chamar na lambda 

```csharp
private readonly IServiceProvider _serviceProvider;

public Function()
{
   _serviceProvider = DependencyInjection.ResolveDependencies();
}
```
