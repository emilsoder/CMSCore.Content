namespace CMSCore.Content.Api.Extensions
{
    using System;
    using CMSCore.Content.Api.Clustering;
    using Microsoft.Extensions.Configuration;
    using Orleans;
    using Orleans.Configuration;
    using Orleans.Hosting;

    public static class ClientBuilderExtensions
    {
        public static AUTH0 Auth0Configuration(this IConfiguration configuration)
        {
            var conn = new AUTH0();
            var section = configuration.GetSection("AUTH0");

            if (section == null || !section.Exists())
            {
                throw new ArgumentException("Section AUTH0 must be provided in 'appsettings.json'. ");
            }

            section.Bind(conn);
            return conn;
        }

        public static ClientBuilder UseAzureTableClustering(this ClientBuilder siloHostBuilder, IConfiguration configuration)
        {
            var connectionString = configuration.AzureClusterSettings().ConnectionString;
            siloHostBuilder
                .UseAzureStorageClustering(options => options.ConnectionString = connectionString)
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "cmscore";
                    options.ServiceId = "cmscore_content";
                });

            return siloHostBuilder;
        }

        public static ClientBuilder UseLocalHostCluster(this ClientBuilder siloHostBuilder)
        {
            siloHostBuilder.UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "HelloWorldApp";
                });

            return siloHostBuilder;
        }

        private static AzureClusterConnection AzureClusterSettings(this IConfiguration configuration)
        {
            var conn = new AzureClusterConnection();
            var section = configuration.GetSection("AZURE_TABLE_CLUSTER");

            if (section == null || !section.Exists())
            {
                throw new ArgumentException("To use Azure table clustering, section AZURE_TABLE_CLUSTER must be provided in 'appsettings.json'. ");
            }

            section.Bind(conn);
            return conn;
        }
    }
}