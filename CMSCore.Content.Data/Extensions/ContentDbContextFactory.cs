namespace CMSCore.Content.Data.Extensions
{
    using System.IO;
    using CMSCore.Content.Data.Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class ContentDbContextFactory : IDesignTimeDbContextFactory<ContentDbContext>
    {
        public ContentDbContext CreateDbContext(string [ ] args)
        {
             return new ContentDbContext(GetConfiguration());
        }

        private static IDataConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();

            return new DataConfiguration(configuration);
        }
    }
}