namespace MPM.DataAccessAwsPostGresql.Interface
{
    public interface ISecretCache
    {
        Task<string> GetSecretValueAsync(string secretName);
    }
}
