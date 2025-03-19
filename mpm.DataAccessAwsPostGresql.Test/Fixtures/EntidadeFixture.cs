

using MPM.DataAccessAwsPostGresql.Entidade;

namespace MPM.DataAccessAwsPostGresql.Test.Fixtures
{
    public class EntidadeFixture
    {
        public static Settings ObterSettings()
        {
            return new Settings
            {
                UsersSecretName = "UserSecret",
                PwdSecretName = "PasswordSecret",
                HostName = "localhost",
                DataBase = "TestDB",
                Port = 5432,
                Environment = "Development"
            };
        }
    }
}
