namespace CMSCore.Content.Grains.Data.Extensions
{
    using Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class ContentDbContextFactory : IDesignTimeDbContextFactory<ContentDbContext>
    {
        public ContentDbContext CreateDbContext(string [ ] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(_dataConfiguration().ContentConnection);

            return new ContentDbContext(optionsBuilder.Options);
        }

        private static IDataConfiguration _dataConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true).Build();

            return new DataConfiguration(configuration);
        }
    }
}