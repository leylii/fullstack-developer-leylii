using System.Security.Cryptography;

namespace CSharpAssessment.Services;

/// <summary>
/// Service for encrypting and decrypting data
/// </summary>
public interface IEncryptionService : IDisposable
{
    /// <summary>
    /// Key used for encryption and decryption
    /// </summary>
    byte[]? Key { get; }
    
    /// <summary>
    /// AES-GCM encryption algorithm instance used for encryption and decryption
    /// </summary>
    AesGcm? AesGcm { get; }
    
    /// <summary>
    /// Encrypts the given data.
    /// Make it as memory efficient as possible and avoid unnecessary allocations.
    /// </summary>
    /// <param name="data">Data to be encrypted</param>
    /// <param name="output">Buffer to store the encrypted data: tag+nonce+data</param>
    /// For example, if the tag is "1234", and the nonce is "5678", and the encryption is "9999", the output should be "123456789999"
    void Encrypt(in ReadOnlySpan<char> data, in Span<byte> output);

    /// <summary>
    /// Decrypts the given data
    /// Make it as memory efficient as possible and avoid unnecessary allocations.
    /// </summary>
    /// <param name="data">The data to decrypt. The data is in format: tag+nonce+encryption</param>
    /// For example, if the tag is "1234", and the nonce is "5678", and the encryption is "9999", the data should be "123456789999"
    /// <returns>The decrypted data</returns>
    string Decrypt(in ReadOnlySpan<byte> data);
}