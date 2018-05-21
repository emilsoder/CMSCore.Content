namespace CMSCore.Content.Api
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using CMSCore.Content.GrainInterfaces;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Orleans;
    using Orleans.Hosting;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Auth0Settings = Configuration.Auth0Configuration();
        }

        public IConfiguration Configuration { get; }
        public AUTH0 Auth0Settings { get; }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMSCore Content API");
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(CreateClusterClient);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Auth0Settings.AUTH0_DOMAIN;
                options.Audience = Auth0Settings.AUTH0_AUDIENCE;
            });
             
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CMSCore Content API", Version = "v1" });
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
                .UseAzureTableClustering(Configuration)
                .ConfigureApplicationParts(parts =>
                {
                    parts.AddApplicationPart(typeof(ICreateContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IUpdateContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IDeleteContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IRecycleBinGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IRestoreContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IReadContentGrain).Assembly).WithReferences();
                })
                .Build();

            StartClientWithRetries(client).Wait();

            return client;
        }
    }
}