using System;
using Microsoft.EntityFrameworkCore;

namespace CMSCore.Content.Data.Extensions
{
    public class ContentDbContextOptions
    {
        public static DbContextOptions DefaultPostgresOptions =>
            new DbContextOptionsBuilder()
                .UseNpgsql(DatabaseConnectionConst.Postgres)
                .Options;

        public static Action<DbContextOptionsBuilder> DefaultPostgresOptionsBuilder
            => builder => new DbContextOptionsBuilder()
                .UseNpgsql(DatabaseConnectionConst.Postgres);

        public static Action<DbContextOptionsBuilder> DefaultSqlServerOptionsBuilder
            => builder => new DbContextOptionsBuilder()
                .UseSqlServer(DatabaseConnectionConst.SqlServer);

        public static DbContextOptions DefaultSqlServerOptions =>
            new DbContextOptionsBuilder()
                .UseSqlServer(DatabaseConnectionConst.SqlServer)
                .Options;
    }
}