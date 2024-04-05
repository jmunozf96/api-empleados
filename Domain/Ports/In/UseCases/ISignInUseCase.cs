
using ApiEmployee.Domain.Models;

namespace ApiEmployee.Domain.Ports.In.Usecases
{
    public interface ISignInUseCase
    {
        OutputSignIn Execute(InputSignIn input);
    }
}
