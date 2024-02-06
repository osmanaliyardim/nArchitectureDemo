namespace Core.Security.JWT;

public class TokenOptions
{
    public string Audience { get; set; }

    public string Issuer { get; set; }

    public int AccessTokenExpiration { get; set; }

    public string SecurityKey { get; set; }

    public int RefrestTokenTTL { get; set; }

    public TokenOptions()
    {
        Audience = string.Empty;
        Issuer = string.Empty;
        SecurityKey = string.Empty;
    }

    public TokenOptions(
        string audience, string ıssuer, int accessTokenExpiration, 
        string securityKey, int refrestTokenTTL)
    {
        Audience = audience;
        Issuer = ıssuer;
        AccessTokenExpiration = accessTokenExpiration;
        SecurityKey = securityKey;
        RefrestTokenTTL = refrestTokenTTL;
    }
}
