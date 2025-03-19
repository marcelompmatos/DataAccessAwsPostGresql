using MPM.DataAccessAwsPostGresql.Configuracao;
using MPM.DataAccessAwsPostGresql.Interface;
using Npgsql;
using System.Diagnostics.CodeAnalysis;

namespace MPM.DataAccessAwsPostGresql.Service
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbConexaoService _dbConexaoService;
        private NpgsqlConnection _connection;
        private NpgsqlTransaction? _transaction; // Marking _transaction as nullable

        public UnitOfWork(DbConexaoService dbConexaoService)
        {
            _dbConexaoService = dbConexaoService;
            _connection = _dbConexaoService.GetConnection();
            _connection.Open();
        }
        public NpgsqlConnection Connection => _connection;
        public NpgsqlTransaction Transaction => _transaction!; // Using null-forgiving operator

        public NpgsqlTransaction BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
            return _transaction;
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}
