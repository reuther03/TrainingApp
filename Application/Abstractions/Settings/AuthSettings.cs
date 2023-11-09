namespace Application.Abstractions.Settings;

public class AuthSettings
{
    public const string SectionName = "AuthSettings";

    public string JwtKey { get; set; } = default!;
    public string JwtIssuer { get; set; } = default!;
    public int JwtExpireMinutes { get; set; } = default!;
}