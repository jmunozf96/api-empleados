namespace ApiEmployee.Domain.Models
{
    public class OutputSignIn(string AccessToken, string RefreshToken)
    {
        public string AccessToken { get; } = AccessToken;
        public string RefreshToken { get; } = RefreshToken;
    }
}
