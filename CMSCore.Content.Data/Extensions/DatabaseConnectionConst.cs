namespace CMSCore.Content.Data.Extensions
{
    public class DatabaseConnectionConst
    {
        public const string POSTGRES_GCP =
            "Host=35.190.218.75;Port=5432;Database=cmscore-content;User ID=postgres; Password=123QWEasd!";

        //public const string SqlServer =
        //    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=cmscore-content;Integrated Security=True;";
        public const string SqlServer =
            "Data Source=STO-PC-681;Initial Catalog=cmscore-content;Integrated Security=False;User ID=cmscore;Password=123QWEasd!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public const string MSSQL_CONTAINER =
            "Data Source=172.25.238.237;Initial Catalog=cmscore-content;Integrated Security=False;User ID=sa;Password=123qweASD!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public const string MYSQL_GCP = "server=35.195.58.124:3306;database=cmscore_content;user=cmscore;password=123QWEasd!";
    }
}

//server=35.195.58.124:3306;database=cmscore_content;user=cmscore;password=123QWEasd! q q