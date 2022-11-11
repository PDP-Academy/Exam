
namespace Imtihon3.Core.Models
{
    public partial class Root
    {
        public string sorting { get; set; }
        //public FilterMapping filterMapping { get; set; }
        public List<object> filterOptions { get; set; }
        public List<object> activeFilterOptions { get; set; }
        public string query { get; set; }
        public int totalResults { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<SearchResult> searchResults { get; set; }
        public long expires { get; set; }
        public bool isStale { get; set; }
    }
}
