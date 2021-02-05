namespace SRContainerSample.Web.ViewModels
{
    public class PostalCodeItem
    {
        public string Key { get; init; }
        public string LocalizedName { get; init; }

        public PostalCodeItem(Models.Accuweather.PostalCodeSearchResultItem item)
        {
            Key = item.Key;
            LocalizedName = item.LocalizedName;
        }
    }
}
