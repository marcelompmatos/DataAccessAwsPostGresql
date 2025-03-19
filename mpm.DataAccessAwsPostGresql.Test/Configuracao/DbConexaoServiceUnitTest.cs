using Microsoft.Extensions.Options;
using Moq;
using MPM.DataAccessAwsPostGresql.Configuracao;
using MPM.DataAccessAwsPostGresql.Entidade;
using MPM.DataAccessAwsPostGresql.Interface;
using Npgsql;

namespace DataAccessAwsPostGreSql.Test.Configuracao
{
    public class DbConexaoServiceUnitTest
    {
        [Fact]
        public void GetConnection_DeveRetornarConexaoValida()
        {
            // Arrange
            var settings = new Settings
            {
                HostName = "localhost",
                Port = 5432,
                DataBase = "testdb",
                UsersSecretName = "testuser",
                PwdSecretName = "testpassword",
            };

            var mockSecretCache = new Mock<ISecretCache>();
            var mockOptions = new Mock<IOptions<Settings>>();
            mockOptions.Setup(opt => opt.Value).Returns(settings);

            var dbConexaoService = new DbConexaoService(mockSecretCache.Object, mockOptions.Object);

            // Act
            var connection = dbConexaoService.GetConnection();

            // Assert
            Assert.NotNull(connection);
            Assert.IsType<NpgsqlConnection>(connection);
            Assert.Equal("Host=localhost;Port=5432;Database=testdb;Username=testuser;Password=testpassword;Pooling=True", connection.ConnectionString);

        }

        [Fact]
        public void GetConnection_DeveLancarExcecao_QuandoFalharAoCriarConexao()
        {
            // Arrange
            var settings = new Settings
            {
                HostName = null, // Forçando erro, já que HostName não pode ser nulo
                Port = 5432,
                DataBase = "TestDB",
                UsersSecretName = "user",
                PwdSecretName = "password"
            };

            var mockSecretCache = new Mock<ISecretCache>();
            var mockSettings = new Mock<IOptions<Settings>>();
            mockSettings.Setup(s => s.Value).Returns(settings);

            var dbConexaoService = new DbConexaoService(mockSecretCache.Object, mockSettings.Object);

            // Act & Assert
           Assert.Throws<InvalidOperationException>(() => dbConexaoService.GetConnection());
        }

        [Fact]
        public void GetConnection_Deve_Lancar_Excecao_Quando_DataSource_Estiver_Nulo()
        {

            var mockSecretCache = new Mock<ISecretCache>();

            var mockSettings = new Mock<IOptions<Settings>>();
            var service = new DbConexaoService(mockSecretCache.Object, mockSettings.Object);
            Assert.Throws<InvalidOperationException>(() => service.GetConnection());
        }
    }
}


