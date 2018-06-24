namespace CMSCore.Content.Data.Configuration
{
    using Microsoft.Extensions.Configuration;

    public class DataConfiguration : IDataConfiguration
    {
        public DataConfiguration(IConfiguration configuration)
        {
            configuration.GetSection("data").Bind(this);
        }

        public string ContentConnection { get; set; }
    }
}