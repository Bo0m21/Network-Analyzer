namespace Network_Analyzer_Backend.Interfaces
{
    public interface ITokenService
    {
        string GetToken(long userId);
        string GenerateToken(long userId);
    }
}