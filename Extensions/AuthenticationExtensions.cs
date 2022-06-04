#pragma warning disable 1591
// From: https://github.com/StefanescuEduard/DotnetSwaggerDocumentation/blob/master/API.WithAuthentication/Extensions/AuthenticationExtensions.cs
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace BlazorFileUploadSwagger
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services,
            byte[] signingKey)
        {
            services.AddAuthentication(authOptions =>
                {
                    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwtOptions =>
                {
                    jwtOptions.SaveToken = true;
                    jwtOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                        ValidateLifetime = true,
                        LifetimeValidator = LifetimeValidator
                    };
                });

            return services;
        }
        private static bool LifetimeValidator(DateTime? notBefore,
            DateTime? expires,
            SecurityToken securityToken,
            TokenValidationParameters validationParameters)
        {
            return expires != null && expires > DateTime.Now;
        }
    }
}
