namespace ApiEmployee.Dtos.Authentications
{
    public class ResponseAuthDTO(string AccessToken, string RefreshToken)
    {
        public string AccessToken { get; } = AccessToken;
        public string RefreshToken { get; } = RefreshToken;
    }
}
