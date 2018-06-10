namespace CMSCore.Content.Data.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class ContentDbContextFactory : IDesignTimeDbContextFactory<ContentDbContext>
    {
        public ContentDbContext CreateDbContext(string [ ] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();

            //optionsBuilder.UseSqlServer(DatabaseConnectionConst.MSSQL_CONTAINER);
            //optionsBuilder.UseMySQL(DatabaseConnectionConst.MYSQL_GCP);
            optionsBuilder.UseNpgsql(DatabaseConnectionConst.POSTGRES_GCP);
            return new ContentDbContext(optionsBuilder.Options);
        }
    }
}