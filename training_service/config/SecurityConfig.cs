using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace training_service.config
{
    public static class SecurityConfig
    {
        public static void AddApiSecurity(this IServiceCollection services)
        {
            // Allows all API endpoints without authentication for development purposes.
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAssertion(_ => true)
                    .Build();
            });
        }
    }
}
