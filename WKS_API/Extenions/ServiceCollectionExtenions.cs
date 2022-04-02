using System.Text;

namespace WKS_API.Extenions
{
    public static class ServiceCollectionExtenions
    {
        public static void AddOcelotJwtBearer(this 
            IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("Jwt");
            var keyByteArray = Encoding.ASCII.GetBytes(config["Secret"]);
            
            
        }
    }
}
