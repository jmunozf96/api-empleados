namespace ApiEmployee.Dtos.Authentications
{
    public class SignInDTO(string Email, string Password)
    {
        public string Email { get; } = Email;
        public string Password { get; } = Password;
    }
}
