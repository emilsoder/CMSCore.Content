namespace CMSCore.Content.Api
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