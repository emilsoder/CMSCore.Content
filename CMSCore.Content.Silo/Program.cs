namespace CMSCore.Content.Silo
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.Loader;
    using System.Threading;
    using System.Threading.Tasks;
    using CMSCore.Content.Data;
    using CMSCore.Content.Data.Configuration;
    using CMSCore.Content.Grains;
    using CMSCore.Content.Repository;
    using CMSCore.Content.Silo.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Orleans;
    using Orleans.Configuration;
    using Orleans.Hosting;

    public class Program
    {
        public static IConfiguration Configuration;
        private static readonly ManualResetEvent siloStopped = new ManualResetEvent(false);
        private static ISiloHost silo;
        private static IClusterConfiguration _clusterConfiguration;

        private static void Main(string [ ] args)
        {
            Configuration = SiloBuilderExtensions.BuildConfiguration();
            _clusterConfiguration = new ClusterConfiguration(Configuration);


            silo = new SiloHostBuilder()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "CMSCore_Cluster1";
                    options.ServiceId = "cmscore-content-api";
                })
                .UseAdoNetClustering(options =>
                {
                    options.Invariant = "System.Data.SqlClient";
                    options.ConnectionString = _clusterConfiguration.StorageConnection;
                })
                .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000, advertisedIP: IPAddress.Loopback)
                .AddAdoNetGrainStorage("OrleansStorage", options =>
                {
                    options.Invariant = "System.Data.SqlClient";
                    options.ConnectionString = _clusterConfiguration.StorageConnection;
                    options.UseJsonFormat = true;
                }).ConfigureServices(x =>
                {
                    //x.AddSingleton<ContentDbContext>(new ContentDbContext());
                    x.AddSingleton<IClusterConfiguration, ClusterConfiguration>();
                    x.AddSingleton<IDataConfiguration>(new DataConfiguration(Configuration));
                    x.AddSingleton<ContentDbContext>();
                    x.AddRepositories();
                })
                .ConfigureApplicationParts(parts =>
                {
                    parts.AddApplicationPart(typeof(CreateContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(UpdateContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(DeleteContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(RecycleBinGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(RestoreContentGrain).Assembly).WithReferences();
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