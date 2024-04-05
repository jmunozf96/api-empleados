using ErpSecurity.Domain.Models;

namespace ErpSecurity.Domain.Ports.In.Usecases
{
    public interface IGetAccessTokenUseCase
    {
        string Execute(InputGetAccessToken input);
    }
}
