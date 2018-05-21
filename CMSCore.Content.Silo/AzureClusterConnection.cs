namespace CMSCore.Content.Silo
{
    public class AzureClusterConnection
    {
        private string _defaultEndpointsProtocol;
        private string _accountName;
        private string _accountKey;

        public string DefaultEndpointsProtocol
        {
            get => _defaultEndpointsProtocol;
            set => _defaultEndpointsProtocol = "DefaultEndpointsProtocol=" + value + ";";
        }

        public string AccountName
        {
            get => _accountName;
            set => _accountName = "AccountName=" + value + ";";
        }

        public string AccountKey
        {
            get => _accountKey;
            set => _accountKey = "AccountKey=" + value + ";";
        }

        public string ConnectionString => DefaultEndpointsProtocol + AccountName + AccountKey;
    }
}

/*const string connectionString =
"DefaultEndpointsProtocol=https;" +
"AccountName=cmscore;" +
"AccountKey=Abc9f2usjENqWPSDSxZt3A97NqRInznfjfhFN07ZgTvBOy+EzPga3XvHii8tFLXjPmuS0QtX09Hv3qkU43xX+g==;" + 
*/