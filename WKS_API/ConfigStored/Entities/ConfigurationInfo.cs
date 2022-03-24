namespace WKS_API.ConfigStored.Entities
{
    public class ConfigurationInfo
    {
        public int GatewayId { get; set; }

        public string GatewayKey { get; set; }
        /// <summary>
        /// baseurl
        /// </summary>
        public string BaseUrl { get; set; } 
        public string DownStreamScheme { get; set; }

        public string RequestIdKey { set; get; }

        public string HttpHandleOptions { get; set; }

        public string HttpHandlerOptions { set; get; }

        public string LoadBalancerOptions { get; set; }
        public string QoSoptions { get; set; }
        public string ServiceDiscoveryProvider { get; set; }
        public string RateLimitOptions { get; set; }
    }
}
