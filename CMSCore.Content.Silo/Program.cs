namespace CMSCore.Content.Silo
{
    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.Loader;
    using System.Threading;
    using System.Threading.Tasks;
    using CMSCore.Content.Data;
    using CMSCore.Content.Grains;
    using CMSCore.Content.Repository;
    using CMSCore.Content.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Orleans;
    using Orleans.Configuration;
    using Orleans.Hosting;

    public class Program
    {
        private static readonly ManualResetEvent siloStopped = new ManualResetEvent(false);
        private static ISiloHost silo;

        private static void Main(string [ ] args)
        {
             silo = new SiloHostBuilder() 
                .UseDashboard(options => { })
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "HelloWorldApp";
                })
                .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
                .ConfigureServices(x =>
                {
                    //x.AddDbContext<ContentDbContext>();
                    x.AddSingleton<ContentDbContext>();
                    x.AddRepositories();
                })
                .ConfigureApplicationParts(parts =>
                {
                    parts.AddApplicationPart(typeof(CreateContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(UpdateContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(DeleteContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(RecycleBinGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(ReadContentGrain).Assembly).WithReferences();
                })
                .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning)
                    .AddConsole())
                .Build();

            Task.Run(StartSilo);

            AssemblyLoadContext.Default.Unloading += context =>
            {
                Task.Run(StopSilo);
                siloStopped.WaitOne();
            };

            siloStopped.WaitOne();
        }

        private static async Task StartSilo()
        {
            await silo.StartAsync();
            Console.WriteLine("Silo started");
        }

        private static async Task StopSilo()
        {
            await silo.StopAsync();
            Console.WriteLine("Silo stopped");
            siloStopped.Set();
        }
    }
}
//public const string _dbConnectionString   = "Data Source=STO-PC-681;Initial Catalog=cmscore-content;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//private static IConfiguration _configuration;

//private static IConfiguration GetConfiguration()
//{
//    if (_configuration != null) return _configuration;

//    var configurationRoot = new ConfigurationBuilder()
//        .SetBasePath(Directory.GetCurrentDirectory())
//        .AddJsonFile("siloconfig.json", true, true)
//        .Build();

//    _configuration = configurationRoot;

//    return _configuration;
//}

//public class ClusterConfiguration
//{
//    public string AzureTableStorage { get; set; }
//    public string SqlServer { get; set; }
//}

//private static ClusterConfiguration GetClusterConfiguration => GetConfiguration().GetValue<ClusterConfiguration>("ClusterConfiguration");
//.Configure<ClusterOptions>(options =>
//{
//    options.ClusterId = "cmscore-content-silo";
//    options.ServiceId = "cmscore.content.silo";
//})
//.UseAzureStorageClustering(options => options.ConnectionString = connectionString)

//private static IConfiguration _configuration;

//private static IConfiguration GetConfiguration()
//{
//    if (_configuration != null) return _configuration;

//    var configurationRoot = new ConfigurationBuilder()
//        .SetBasePath(Directory.GetCurrentDirectory())
//        .AddJsonFile("siloconfig.json", true, true)
//        .Build();

//    _configuration = configurationRoot;

//    return _configuration;
//}

//public class ClusterConfiguration
//{
//    public string AzureTableStorage { get; set; }
//}

//private static ClusterConfiguration GetClusterConfiguration => GetConfiguration().GetValue<ClusterConfiguration>("ClusterConfiguration");
//var connectionString = GetClusterConfiguration.AzureTableStorage;