using CSharpAssessment.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpAssessment.Tests;

public class ProcessingServiceTests
{
    [Fact]
    [Trait("Service", "ProcessingService")]
    public void DI_WhenProcessingServiceIsRegistered_ShouldResolveIProcessingService()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();

        // Act
        var processingService = serviceProvider.GetService<IProcessingService>();

        // Assert
        Assert.NotNull(processingService);
    }
    
    [Theory]
    [Trait("Service", "ProcessingService")]
    [InlineData(10, 10)]
    [InlineData(5, 10)]
    [InlineData(2, 10)]
    public async Task ProcessDataAsync_Should_Handle_Concurrency(int iterations, int timeoutSeconds)
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();
        var processingService = serviceProvider.GetRequiredService<IProcessingService>();
        var data = Enumerable.Range(0, 1000).ToArray();
        using var cts = new CancellationTokenSource();

        // Act
        var result = await processingService.ProcessIntegerArrayAsync(data, iterations, timeoutSeconds, cts.Token);

        // Assert
        Assert.NotEqual(0, result);
    }
    
    [Fact]
    [Trait("Service", "ProcessingService")]
    public async Task ProcessDataAsync_Should_Handle_Cancellation()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();
        var processingService = serviceProvider.GetRequiredService<IProcessingService>();
        var data = Enumerable.Range(0, 1000).ToArray();
        using var cts = new CancellationTokenSource();

        // Act
        cts.CancelAfter(1);
        await Assert.ThrowsAsync<OperationCanceledException>(() => processingService.ProcessIntegerArrayAsync(data, 10, 10, cts.Token));
    }
    
    [Fact]
    [Trait("Service", "ProcessingService")]
    public async Task ProcessDataAsync_Should_Handle_Timeout()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();
        var processingService = serviceProvider.GetRequiredService<IProcessingService>();
        var data = Enumerable.Range(0, 10_000).ToArray();

        // Act
        await Assert.ThrowsAsync<TimeoutException>(() => processingService.ProcessIntegerArrayAsync(data, int.MaxValue, 1, default));
    }
    
    [Fact]
    [Trait("Service", "ProcessingService")]
    public async Task AddUserAsync_Should_Throw_ArgumentException_When_User_Is_Not_Valid()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();
        var processingService = serviceProvider.GetRequiredService<IProcessingService>();

        var users = new List<User>
        {
            new("username", "fullname", "email@email.com", DateTime.Now.AddYears(-10)),
        };
        
        // Act
        // duplicate username
        var user1 = new User("username", "fullname", "email1@email.com", DateTime.Now.AddYears(-10));
        // invalid fullname
        var user2 = new User("username2", null, "email2@email.com", DateTime.Now.AddYears(-10));
        // invalid email
        var user3 = new User("username3", "fullname", "email", DateTime.Now.AddYears(-10));
        // future date of birth
        var user4 = new User("username4", "fullname", "email4@email.com", DateTime.Now.AddYears(10));
        // valid user
        var user5 = new User("username5", "fullname", "email5@email.com", DateTime.Now.AddYears(-10));

        // Assert
        await Assert.ThrowsAsync<ArgumentException>(() => processingService.AddUserAsync(user1, users));
        await Assert.ThrowsAsync<ArgumentException>(() => processingService.AddUserAsync(user2, users));
        await Assert.ThrowsAsync<ArgumentException>(() => processingService.AddUserAsync(user3, users));
        await Assert.ThrowsAsync<ArgumentException>(() => processingService.AddUserAsync(user4, users));
        await processingService.AddUserAsync(user5, users);
        
        Assert.Equal(2, users.Count);
    }

    [Fact]
    [Trait("Service", "ProcessingService")]
    public async Task RemoveUserAsync_Should_Remove_User()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();
        var processingService = serviceProvider.GetRequiredService<IProcessingService>();

        var users = new List<User>
        {
            new("username1", "fullname", "email1@email.com", DateTime.Now.AddYears(-10)),
        };

        // Act
        await processingService.RemoveUserAsync("username1", users);

        // Assert
        Assert.Empty(users);
    }

    [Fact]
    [Trait("Service", "ProcessingService")]
    public async Task UpdateUserAsync_Should_Update_User()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();
        var processingService = serviceProvider.GetRequiredService<IProcessingService>();

        var users = new List<User>
        {
            new("username1", "fullname", "email1@email.com", DateTime.Now.AddYears(-10)),
        };

        // Act
        // does not exist
        var user1 = new User("username", "fullname", "email1@email.com", DateTime.Now.AddYears(-10));
        // invalid fullname
        var user2 = new User("username1", null, "email2@email.com", DateTime.Now.AddYears(-10));
        // invalid email
        var user3 = new User("username1", "fullname", "email", DateTime.Now.AddYears(-10));
        // future date of birth
        var user4 = new User("username1", "fullname", "email4@email.com", DateTime.Now.AddYears(10));
        // valid user
        var user5 = new User("username1", "fullname1", "email5@email.com", DateTime.Now.AddYears(-10));

        // Assert
        await Assert.ThrowsAsync<ArgumentException>(() => processingService.UpdateUserAsync(user1, users));
        await Assert.ThrowsAsync<ArgumentException>(() => processingService.UpdateUserAsync(user2, users));
        await Assert.ThrowsAsync<ArgumentException>(() => processingService.UpdateUserAsync(user3, users));
        await Assert.ThrowsAsync<ArgumentException>(() => processingService.UpdateUserAsync(user4, users));
        await processingService.AddUserAsync(user5, users);
        
        Assert.Single(users);
        Assert.Equal("fullname1", users.First().FullName);
        Assert.Equal("email5@email.com", users.First().Email);
    }

    [Fact]
    [Trait("Service", "ProcessingService")]
    public async Task GetUsersOlderThanAsync_Should_Return_Users_Older_Than_Given_Age()
    {
        // Arrange
        var serviceProvider = Helpers.GetServiceProvider();
        var processingService = serviceProvider.GetRequiredService<IProcessingService>();

        var users = new List<User>
        {
            new("username1", "fullname1", "email1@email.com", DateTime.Now.AddYears(-10)),
            new("username2", "fullname2", "email2@email.com", DateTime.Now.AddYears(-25)),
            new("username3", "fullname2", "email3@email.com", DateTime.Now.AddYears(-30)),
            new("username4", "fullname3", "email4@email.com", DateTime.Now.AddYears(-40)),
        };

        // Act
        var result = await processingService.GetUsersOlderThanAsync(20, users);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(2, result["fullname2"].Count());
        Assert.Single(result["fullname3"]);
    }
}