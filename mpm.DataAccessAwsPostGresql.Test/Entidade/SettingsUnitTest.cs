using MPM.DataAccessAwsPostGresql.Entidade;
using MPM.DataAccessAwsPostGresql.Test.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPM.DataAccessAwsPostGresql.Test.Entidade
{
    public class SettingsUnitTest
    {
        [Fact]
        public void Settings_Should_Initialize_With_Default_Values()
        {
            // Arrange & Act
            var settings = new Settings();

            // Assert
            Assert.Null(settings.UsersSecretName);
            Assert.Null(settings.PwdSecretName);
            Assert.Null(settings.HostName);
            Assert.Null(settings.DataBase);
            Assert.Equal(0, settings.Port);
            Assert.Null(settings.Environment);
        }
        [Fact]
        public void Settings_Should_Assign_Values_Correctly()
        {
            // Arrange & Act
            var settings =  EntidadeFixture.ObterSettings();

            // Assert
            Assert.Equal("UserSecret", settings.UsersSecretName);
            Assert.Equal("PasswordSecret", settings.PwdSecretName);
            Assert.Equal("localhost", settings.HostName);
            Assert.Equal("TestDB", settings.DataBase);
            Assert.Equal(5432, settings.Port);
            Assert.Equal("Development", settings.Environment);
        }
    }
}
   