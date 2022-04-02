using Microsoft.AspNetCore.Authentication;
using Ocelot.Configuration.Repository;
using Ocelot.DependencyInjection;
using WKS_API.ConfigStored;

namespace WKS_API.Extenions
{
    public static class OcelotExtenions
    {
        public static IOcelotBuilder AddCOnfigStoredInMysql(this IOcelotBuilder builder, string apiGatewayKey)
        {
            builder.Services.AddHostedService<FileConfigurationPoller>();
            builder.Services.AddSingleton<IFileConfigurationRepository>(options =>
            {
                return new MySqlFileConfigurationRepository(options, apiGatewayKey);
            });
            return builder;
        }

        public static AuthenticationBuilder AddOcelotJwtBearer(this IServiceCollection services, string
            issuer, string audience, string secret, string defaultScheme, bool isHttp = false)
        { 

        }
    }
}
