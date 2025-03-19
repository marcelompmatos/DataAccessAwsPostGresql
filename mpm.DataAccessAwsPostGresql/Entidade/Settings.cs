namespace MPM.DataAccessAwsPostGresql.Entidade
{
    public class Settings
    {
        public string? UsersSecretName { get; set; }
        public string? PwdSecretName { get; set; }
        public string? HostName { get; set; }
        public string? DataBase { get; set; }
        public int Port { get; set; }
        public string? Environment { get; set; }
    }
}
