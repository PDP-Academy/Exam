using System;
namespace pdpexam
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class User
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public double[] GeoCode { get; set; } = new double[2];
        public long TgId { get; set; }
        public Status UserStatus { get; set; }
    }

    public enum Status
    {
        name,
        number,
        geocode,
        registred
    }

    public class FilterMapping
    {
    }

    public class Result
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string link { get; set; }
        public string type { get; set; }
        public int relevance { get; set; }
        public string content { get; set; }
        public List<object> dataPoints { get; set; }
    }

    public class Root
    {
        public string sorting { get; set; }
        public FilterMapping filterMapping { get; set; }
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

    public class SearchResult
    {
        public string name { get; set; }
        public string type { get; set; }
        public int totalResults { get; set; }
        public int totalResultsVariants { get; set; }
        public List<Result> results { get; set; }
    }


}

