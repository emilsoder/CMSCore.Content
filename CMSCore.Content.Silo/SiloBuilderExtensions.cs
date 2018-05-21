namespace CMSCore.Content.Silo
{
    using System;
    using System.IO;
    using System.Net;
    using Microsoft.Extensions.Configuration;
    using Orleans.Configuration;
    using Orleans.Hosting;

    public static class SiloBuilderExtensions
    {
        public static IConfigurationRoot BuildConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("siloconfig.json", true, true);

            return configuration.Build();
        }

        public static ISiloHostBuilder UseAzureTableClustering(this ISiloHostBuilder siloHostBuilder, IConfiguration configuration)
        {
            var connectionString = configuration.AzureClusterSettings().ConnectionString;
            siloHostBuilder
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "cmscore";
                    options.ServiceId = "cmscore_content";
                })
                .UseAzureStorageClustering(options => options.ConnectionString = connectionString)
                .ConfigureEndpoints(11111, 30000);

            return siloHostBuilder;
        }

        public static ISiloHostBuilder UseLocalHostCluster(this ISiloHostBuilder siloHostBuilder)
        {
            siloHostBuilder.UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "HelloWorldApp";
                })
                .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback);

            return siloHostBuilder;
        }

        private static AzureClusterConnection AzureClusterSettings(this IConfiguration configuration)
        {
            var conn = new AzureClusterConnection();
            var section = configuration.GetSection("AZURE_TABLE_CLUSTER");

            if (section == null || !section.Exists())
            {
                throw new ArgumentException("To use Azure table clustering, section AZURE_TABLE_CLUSTER must be provided in 'silosettings.json'. ");
            }

            section.Bind(conn);
            return conn;
        }
    }
}