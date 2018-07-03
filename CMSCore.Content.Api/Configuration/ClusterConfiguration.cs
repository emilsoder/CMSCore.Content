namespace CMSCore.Content.Api.Configuration
{
    using Microsoft.Extensions.Configuration;

    public class ClusterConfiguration : IClusterConfiguration
    {
        public ClusterConfiguration(IConfiguration configuration)
        {
            configuration.GetSection("cluster").Bind(this);
        }

        public string StorageConnection { get; set; }
    }
}