using CSharpAssessment.Options;
using CSharpAssessment.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CSharpAssessment.Tests;

public class EncryptionServiceTests
{
    [Fact]
    [Trait("Service", "EncryptionService")]
    public void DI_WhenEncryptionServiceIsRegistered_ShouldResolveIEncryptionService()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();

        // Act
        var encryptionService = serviceProvider.GetService<IEncryptionService>();
        var encryptionServiceOptions = serviceProvider.GetService<IOptions<EncryptionServiceOptions>>();

        // Assert
        Assert.NotNull(encryptionServiceOptions);
        Assert.NotNull(encryptionService);
    }

    [Fact]
    [Trait("Service", "EncryptionService")]
    public void Key_Should_Be_Derived()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();

        var encryptionService = serviceProvider.GetRequiredService<IEncryptionService>();
        var encryptionServiceOptions = serviceProvider.GetRequiredService<IOptions<EncryptionServiceOptions>>();

        // Act
        var key = Helpers.GetKey(encryptionServiceOptions.Value);
        
        // Assert
        Assert.NotNull(key);
        Assert.NotNull(encryptionService.Key);
        Assert.True(encryptionService.Key.AsSpan().SequenceEqual(key));
    }
    
    [Fact]
    [Trait("Service", "EncryptionService")]
    public void Encrypt_Should_Encrypt_Decrypt_Data()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();

        var encryptionService = serviceProvider.GetRequiredService<IEncryptionService>();
        
        // Act
        var data = "Hello, World!";
        
        var buffer = new byte[1024];
        
        encryptionService.Encrypt(data.AsSpan(), buffer);
        var decryptedData = encryptionService.Decrypt(buffer);
        
        // Assert
        Assert.Equal(data, decryptedData);
    }

    [Fact]
    [Trait("Service", "EncryptionService")]
    public void EncryptService_Disposed()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();

        var encryptionService = serviceProvider.GetRequiredService<IEncryptionService>();
        
        // Act
        encryptionService.Dispose();
        
        var data = "Hello, World!";
        
        var buffer = new byte[1024];
        
        // Assert
        Assert.Throws<ObjectDisposedException>(() => encryptionService.Encrypt(data, buffer));
    }
}