namespace CMSCore.Content.Api
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Orleans;
    using Orleans.Configuration;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        public const string AUTH0_AUDIENCE = "http://localhost:50467/api";
        public const string AUTH0_DOMAIN = "https://cmscore-prod.eu.auth0.com";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(CreateClusterClient);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = AUTH0_DOMAIN;
                options.Audience = AUTH0_AUDIENCE;
            });
        }

        private static async Task StartClientWithRetries(IClusterClient client)
        {
            for (var i = 0; i < 5; i++)
            {
                try
                {
                    await client.Connect();
                    return;
                }
                catch (Exception) { }

                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        private IClusterClient CreateClusterClient(IServiceProvider serviceProvider)
        {
            var client = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "HelloWorldApp";
                })
                .ConfigureApplicationParts(parts =>
                {
                    parts.AddApplicationPart(typeof(ICreateContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IUpdateContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IDeleteContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IRecycleBinGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IReadContentGrain).Assembly).WithReferences();
                })
                .Build();

            StartClientWithRetries(client).Wait();

            return client;
        }
    }
}