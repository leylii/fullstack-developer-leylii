using System.Security.Cryptography;
using System.Text;
using CSharpAssessment.Extensions;
using CSharpAssessment.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpAssessment.Tests;

public static class Helpers
{
    public static IServiceProvider GetServiceProvider()
    {
        var configuration =  new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.json")
            .Build();
        var services = new ServiceCollection();
        services.AddLogging().AddOptions()
            .AddSingleton<IConfiguration>(configuration);
        services.AddTaskServices();
        return services.BuildServiceProvider();
    }

    public static byte[] GetKey(EncryptionServiceOptions options)
    {
        using var deriveBytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(options.Password),
            Encoding.UTF8.GetBytes(options.Salt), options.Iterations, Enum.Parse<HashAlgorithmName>(options.Algorithm));
        return deriveBytes.GetBytes(options.KeySize);
    }
}