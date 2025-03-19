using Npgsql;

namespace MPM.DataAccessAwsPostGresql.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public NpgsqlConnection Connection { get; }
        public NpgsqlTransaction Transaction { get; }
        NpgsqlTransaction BeginTransaction();
        void CommitTransaction();
        void Rollback();
    }
}
