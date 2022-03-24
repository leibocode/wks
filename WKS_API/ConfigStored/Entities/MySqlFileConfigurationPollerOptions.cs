using Ocelot.Configuration.Repository;

namespace WKS_API.ConfigStored.Entities
{
    public class MySqlFileConfigurationPollerOptions : IFileConfigurationPollerOptions
    {
        public int Delay => 3000;
    }
}
