namespace CMSCore.Content.Repository
{
    using Interfaces;
    using Implementations;
    using Microsoft.Extensions.DependencyInjection;
     
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ICreateContentRepository, CreateContentRepository>();
            services.AddSingleton<IUpdateContentRepository, UpdateContentRepository>();
            services.AddSingleton<IDeleteContentRepository, DeleteContentRepository>();
            services.AddSingleton<IReadContentRepository, ReadContentRepository>();
            services.AddSingleton<IRecycleBinRepository, RecycleBinRepository>();

            return services;
        }
    }
}