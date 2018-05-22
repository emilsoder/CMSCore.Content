namespace CMSCore.Content.Silo
{
    using System;
    using System.Runtime.Loader;
    using System.Threading;
    using System.Threading.Tasks;
    using CMSCore.Content.Data;
    using CMSCore.Content.Grains;
    using CMSCore.Content.Repository;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Orleans;
    using Orleans.Hosting;

    public class Program
    {
        public static IConfiguration Configuration;
        private static readonly ManualResetEvent siloStopped = new ManualResetEvent(false);
        private static ISiloHost silo;


        private static void Main(string [ ] args)
        {
            Configuration = SiloBuilderExtensions.BuildConfiguration();

            silo = new SiloHostBuilder()
                .UseDashboard(options => { options.HideTrace = true; })
                .UseAzureTableClustering(Configuration)
                .ConfigureServices(x =>
                {
                    x.AddSingleton<ContentDbContext>(new ContentDbContext(Configuration["CONTENT_DB:MSSQL_CONTAINER"]));
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
                .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Information)
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