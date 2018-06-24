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
                .AddJsonFile("appsettings.json", true, true);

            return configuration.Build();
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

      
    }
}