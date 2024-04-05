using ErpSecurity.Domain.Ports.In.Usecases;
using Microsoft.Extensions.Options;
using ApiEmployee.Domain.Ports.In.Usecases;
using Domain.Ports.Out;
using Shared.Options;
using ApiEmployee.Domain.Models;

namespace ErpSecurity.Application.Usecases
{
    public class SignInUseCase : ISignInUseCase
    {
        private readonly UserRepositoryPort _repositoryPort;
        private readonly IGetAccessTokenUseCase _getAccessTokenUseCase;
        private readonly JwtOption _jwtOption;

        public SignInUseCase(UserRepositoryPort repositoryPort, IGetAccessTokenUseCase getAccessTokenUseCase, IOptionsSnapshot<JwtOption> jwtOption)
        {
            _repositoryPort = repositoryPort;
            _getAccessTokenUseCase = getAccessTokenUseCase;
            _jwtOption = jwtOption.Value;
        }

        public OutputSignIn Execute(InputSignIn entity)
        {
            var user = _repositoryPort.GetByEmail(email: entity.Email);
            bool verified = BCrypt.Net.BCrypt.Verify(entity.Password, user.Password);

            if (!verified)
            {
                throw new Exception("La contraseña no es correcta.");
            }

            var accessToken = _getAccessTokenUseCase.Execute(new(user, _jwtOption.DurationTokenInMinutes, _jwtOption.Key));
            var refreshToken = _getAccessTokenUseCase.Execute(new(user, _jwtOption.RefreshKey));

            return new(accessToken, refreshToken);
        }
    }
}
