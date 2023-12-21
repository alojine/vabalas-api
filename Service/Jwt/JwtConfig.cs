namespace vabalas_api.Service.Jwt;

public class JwtConfig
{
    public string Secret { get; set; }
    public int ExpirationInHours { get; set; }
}