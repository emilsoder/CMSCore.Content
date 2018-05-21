namespace CMSCore.Content.Api
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