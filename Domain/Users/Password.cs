using System.Security.Cryptography;

namespace Domain.Users;

public static class PasswordHasher
{
    private const char SegmentDelimiter = ':';
    private const int KeySize = 32;
    private const int SaltSize = 16;
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

    public static string Hash(string rawTextInput)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(rawTextInput, salt, Iterations, Algorithm, KeySize);
        return string.Join(SegmentDelimiter, Convert.ToBase64String(hash), Convert.ToBase64String(salt), Iterations,
            Algorithm);
    }

    public static bool Verify(string rawTextInput, string hashString)
    {
        var segments = hashString.Split(SegmentDelimiter);
        var hash = Convert.FromBase64String(segments[0]);
        var salt = Convert.FromBase64String(segments[1]);
        var iterations = int.Parse(segments[2]);
        var algorithm = new HashAlgorithmName(segments[3]);
        var inputHash = Rfc2898DeriveBytes.Pbkdf2(rawTextInput, salt, iterations, algorithm, hash.Length);
        return CryptographicOperations.FixedTimeEquals(inputHash, hash);
    }
}