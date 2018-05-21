namespace CMSCore.Content.Data.Extensions
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public class ContentDbContextOptions
    {
        public static DbContextOptions DefaultSqlServerOptions =>
            new DbContextOptionsBuilder()
                .UseSqlServer(DatabaseConnectionConst.SqlServer)
                .Options;
        //public static DbContextOptions DefaultPostgresOptions =>
        //    new DbContextOptionsBuilder()
        //        .UseNpgsql(DatabaseConnectionConst.Postgres)
        //        .Options;

        //public static Action<DbContextOptionsBuilder> DefaultPostgresOptionsBuilder
        //    => builder => new DbContextOptionsBuilder()
        //        .UseNpgsql(DatabaseConnectionConst.Postgres);

        public static Action<DbContextOptionsBuilder> DefaultSqlServerOptionsBuilder
            => builder => new DbContextOptionsBuilder()
                .UseSqlServer(DatabaseConnectionConst.SqlServer);
    }
}