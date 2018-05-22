namespace CMSCore.Content.Data.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class ContentDbContextFactory : IDesignTimeDbContextFactory<ContentDbContext>
    {
        public ContentDbContext CreateDbContext(string [ ] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlServer(DatabaseConnectionConst.MSSQL_CONTAINER);

            return new ContentDbContext(optionsBuilder.Options);
        }
    }
}