namespace CMSCore.Content.Data.Extensions
{
    public class DatabaseConnectionConst
    {
        public const string Postgres =
            "Host=localhost;Port=5432;Database=cmscoredb_dev3;User ID=postgres; Password=postgres";

        public const string SqlServer =
            "Data Source=STO-PC-681;Initial Catalog=cmscore-content;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}