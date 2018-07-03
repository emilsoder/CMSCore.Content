namespace CMSCore.Content.Api
{
    using System;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using CMSCore.Content.Api.Attributes;
    using CMSCore.Content.Api.Authorization;
    using CMSCore.Content.Api.Extensions;
    using CMSCore.Content.GrainInterfaces;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Orleans;
    using Orleans.Configuration;
    using Orleans.Hosting;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _authenticationConfiguration = new AuthenticationConfiguration(Configuration);
        }

        public IAuthenticationConfiguration _authenticationConfiguration { get; }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
            });
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMSCore Content API"); });

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => { options.Filters.Add(typeof(ValidateModelStateAttribute)); });
            services.AddSingleton(CreateClusterClient);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IClusterConfiguration, ClusterConfiguration>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = _authenticationConfiguration.AUTH0_DOMAIN;
                options.Audience = _authenticationConfiguration.AUTH0_AUDIENCE;
            });

            services.AddAuthorization(options => { options.SetPoliciesFromConfiguration(_authenticationConfiguration); });

            services.AddSingleton<IAuthorizationHandler, HasRolePolicyHandler>();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "CMSCore Content API", Version = "v1" }); });
        }

        private IClusterClient CreateClusterClient(IServiceProvider serviceProvider)
        {
            var clusterConfiguration = serviceProvider.GetService<IClusterConfiguration>();
            var client = new ClientBuilder()
                .ConfigureApplicationParts(parts =>
                {
                    parts.AddApplicationPart(typeof(ICreateContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IUpdateContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IDeleteContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IRecycleBinGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IRestoreContentGrain).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(IReadContentGrain).Assembly).WithReferences();
                }).Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "CMSCore_Cluster1";
                    options.ServiceId = "cmscore-content-api";
                })
                .UseAdoNetClustering(options =>
                {
                    options.ConnectionString = clusterConfiguration.StorageConnection;
                    options.Invariant = "System.Data.SqlClient";
                })
                .Build();

            StartClientWithRetries(client).Wait();

            return client;
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
                catch (Exception)
                {
                }

                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}