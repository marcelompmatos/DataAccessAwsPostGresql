using Npgsql;

namespace MPM.DataAccessAwsPostGresql.Interface
{
    public interface IDbConexaoService
    {
        NpgsqlConnection GetConnection();
    }
}
