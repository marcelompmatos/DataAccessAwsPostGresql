using Microsoft.Extensions.Options;
using MPM.DataAccessAwsPostGresql.Entidade;
using MPM.DataAccessAwsPostGresql.Interface;
using Npgsql;

namespace MPM.DataAccessAwsPostGresql.Configuracao
{
    public class DbConexaoService : IDbConexaoService
    {
        private readonly Settings _settings;
        private readonly ISecretCache _secretCache;
        private readonly NpgsqlConnectionStringBuilder _connectionBuilder;
        public DbConexaoService(ISecretCache secretCache, IOptions<Settings> settings)
        {
            _settings = settings.Value;
            _secretCache = secretCache;
            _connectionBuilder = new NpgsqlConnectionStringBuilder();
        }
        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection? conexao = null;
            try
            {
                if (_settings is null)
                    throw new InvalidOperationException("Configurações de conexão não foram fornecidas.");

                _connectionBuilder.Host = _settings.HostName;
                _connectionBuilder.Port = _settings.Port;
                _connectionBuilder.Database = _settings.DataBase;
                _connectionBuilder.Username = _settings.UsersSecretName;
                _connectionBuilder.Password = _settings.PwdSecretName;
                _connectionBuilder.Pooling = true;
                conexao = new NpgsqlConnection(_connectionBuilder.ConnectionString);

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar conexão com o banco de dados.", ex);
            }
            return new NpgsqlConnection(_connectionBuilder.ConnectionString);
        }
    }
}
