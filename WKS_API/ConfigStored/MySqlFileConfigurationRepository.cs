using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.Responses;

namespace WKS_API.ConfigStored
{
    public class MySqlFileConfigurationRepository : IFileConfigurationRepository
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _apiGatewayKey;

        public MySqlFileConfigurationRepository(IServiceProvider serviceProvider,string apiGatewaykey)
        { 
            _serviceProvider = serviceProvider;
            _apiGatewayKey = apiGatewaykey;
        }

        /// <summary>
        /// 获取数据库存在apigateway
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<FileConfiguration>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Set(FileConfiguration fileConfiguration)
        {
            return await Task.FromResult(new OkResponse());
        }

       
    }
}
