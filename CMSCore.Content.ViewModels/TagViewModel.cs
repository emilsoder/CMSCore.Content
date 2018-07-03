namespace CMSCore.Content.ViewModels
{

    public class TagViewModel
    {
        public TagViewModel()
        {
            
        }
        public TagViewModel(string id, string normalizedName, string name)
        {
            Id = id;
            NormalizedName = normalizedName;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }

 }