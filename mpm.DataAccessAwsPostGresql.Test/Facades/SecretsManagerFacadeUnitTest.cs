using Amazon.SecretsManager.Model;
using Amazon.SecretsManager;
using Moq;
using MPM.DataAccessAwsPostGresql.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPM.DataAccessAwsPostGresql.Test.Facades
{
    public class SecretsManagerFacadeUnitTest
    {
        //[Fact]
        //public async Task GetSecretValueAsync_ValidKey_ReturnsSecret()
        //{
        //    // Arrange
        //    var mockAmazonSecretsManager = new Mock<IAmazonSecretsManager>();
        //    mockAmazonSecretsManager
        //        .Setup(s => s.GetSecretValueAsync(
        //            It.Is<GetSecretValueRequest>(r => r.SecretId == "testKey"),
        //            It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(new GetSecretValueResponse { SecretString = "testSecret" });

        //    var facade = new SecretsManagerFacade(mockAmazonSecretsManager.Object);

        //    // Act
        //    var result = await facade.GetSecretValueAsync("testKey");

        //    // Assert
        //    Assert.Equal("testSecret", result);
        //}
        //[Fact]
        //public async Task GetSecretValueAsync_AwsThrowsException_PropagatesException()
        //{
        //    // Arrange
        //    var mockAmazonSecretsManager = new Mock<IAmazonSecretsManager>();
        //    mockAmazonSecretsManager
        //        .Setup(s => s.GetSecretValueAsync(
        //            It.IsAny<GetSecretValueRequest>(),
        //            It.IsAny<CancellationToken>()))
        //        .ThrowsAsync(new AmazonSecretsManagerException("AWS error"));

        //    var facade = new SecretsManagerFacade(mockAmazonSecretsManager.Object);

        //    // Act & Assert
        //    await Assert.ThrowsAsync<AmazonSecretsManagerException>(
        //        () => facade.GetSecretValueAsync("testKey"));
        //}

        //[Fact]
        //public async Task GetSecretValueAsync_CalledTwiceWithinCacheTTL_CallsAwsOnce()
        //{
        //    // Arrange
        //    var mockAmazonSecretsManager = new Mock<IAmazonSecretsManager>();
        //    mockAmazonSecretsManager
        //        .Setup(s => s.GetSecretValueAsync(
        //            It.IsAny<GetSecretValueRequest>(),
        //            It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(new GetSecretValueResponse { SecretString = "testSecret" });

        //    var facade = new SecretsManagerFacade(mockAmazonSecretsManager.Object);

        //    // Act
        //    await facade.GetSecretValueAsync("testKey");
        //    await facade.GetSecretValueAsync("testKey");

        //    // Assert
        //    mockAmazonSecretsManager.Verify(
        //        s => s.GetSecretValueAsync(
        //            It.IsAny<GetSecretValueRequest>(),
        //            It.IsAny<CancellationToken>()),
        //        Times.Once);
        //}
    }
}

