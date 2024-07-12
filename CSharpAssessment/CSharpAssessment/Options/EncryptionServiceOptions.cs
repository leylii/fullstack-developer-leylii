namespace CSharpAssessment.Options;

public class EncryptionServiceOptions
{
    public required string Password { get; set; }
    public required string Salt { get; set; }
    public required int Iterations { get; set; }
    public required string Algorithm { get; set; }
    public required int KeySize { get; set; }
}