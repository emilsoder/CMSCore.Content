using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CMSCore.Content.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) { }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.HasValue && context.Request.Path.Value != "/")
                {
                    context.Response.ContentType = "text/html";

                    await context.Response.SendFileAsync(
                        env.ContentRootFileProvider.GetFileInfo("wwwroot/client/index.html")
                    );

                    return;
                }

                await next();
            });
        }
    }
}