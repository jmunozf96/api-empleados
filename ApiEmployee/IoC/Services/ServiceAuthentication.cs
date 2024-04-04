using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shared.Options;
using System.Text;

namespace ErpIoc
{
    public static class ServiceAuthentication
    {
        public static IServiceCollection AddServiceAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptionSection = configuration.GetSection(JwtOption.Jwt);
            JwtOption jwtSetting = jwtOptionSection.Get<JwtOption>()!;
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            return services;
        }
    }
}
