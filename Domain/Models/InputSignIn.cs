namespace ApiEmployee.Domain.Models
{
    public class InputSignIn(string Email, string Password)
    {
        public string Email { get; } = Email;
        public string Password { get; } = Password;
    }
}
