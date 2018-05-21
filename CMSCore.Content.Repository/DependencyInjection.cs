namespace CMSCore.Content.Repository
{
    using CMSCore.Content.Repository.Implementations;
    using CMSCore.Content.Repository.Interfaces;
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