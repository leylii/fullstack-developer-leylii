namespace CSharpAssessment.Services;

/// <summary>
/// Service for processing data asynchronously
/// </summary>
public interface IProcessingService
{
    /// <summary>
    /// Processes the given list of integers asynchronously for the given number of iterations.
    /// Every iteration, the service should power each integer by the (index of the integer in the list + iteration), then sum all the powered integers.
    /// Please note: The method should handle each of the iterations concurrently.
    /// Please note: If the cancellation token is triggered, the method should throw OperationCanceledException.
    /// Please note: The method should implement timeout. If the timeout is triggered, the method should throw TimeoutException.
    /// </summary>
    /// <param name="data">List of integers</param>
    /// <param name="iterations">Number of iterations</param>
    /// <param name="timeoutSeconds">Time in seconds before it triggers timeout</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<long> ProcessIntegerArrayAsync(in ReadOnlySpan<int> data, int iterations, int timeoutSeconds, CancellationToken cancellationToken);
    
    /// <summary>
    /// Adds the given user to the list of users.
    /// Validations: The Username should be unique. The Email should be unique. The DateOfBirth should be in the past. The FullName should not be empty and should contain name and surname. The Email should be a valid email address.
    /// If the user is not valid, the method should throw an ArgumentException.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="users"></param>
    /// <returns></returns>
    Task AddUserAsync(User user, IEnumerable<User> users);
    
    /// <summary>
    /// Removes the user with the given username from the list of users.
    /// If the user is not found, the method should throw an ArgumentException.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="users"></param>
    /// <returns></returns>
    Task RemoveUserAsync(string username, IEnumerable<User> users);
    
    /// <summary>
    /// Updates the user with the given username from the list of users.
    /// The search should be done by the username. If the user is not found, the method should throw an ArgumentException.
    /// Validations: The Username should be unique. The Email should be unique. The DateOfBirth should be in the past. The FullName should not be empty and should contain name and surname. The Email should be a valid email address.
    /// If the user is not valid, the method should throw an ArgumentException.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="users"></param>
    /// <returns></returns>
    Task UpdateUserAsync(User user, IEnumerable<User> users);
    
    /// <summary>
    /// Gets the users older than the given age.
    /// The users should be grouped by FullName and ordered by the DateOfBirth in ascending order.
    /// The age should be calculated based on the current date and the DateOfBirth of the user.
    /// For example, if the age is 18, all users with DateOfBirth older than 18 years should be returned.
    /// </summary>
    /// <param name="age"></param>
    /// <param name="users"></param>
    /// <returns></returns>
    Task<Dictionary<string, IEnumerable<User>>> GetUsersOlderThanAsync(int age, IEnumerable<User> users);
}

public record User(string Username, string? FullName, string Email, DateTime DateOfBirth);