using System.Text.Json.Serialization;

namespace ExamModul3.Model
{
    public class FilterMapping
    {
    }

    public class Result
    {
        [JsonPropertyName("id")]
        public int Id;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("image")]
        public string Image;

        [JsonPropertyName("link")]
        public string Link;

        [JsonPropertyName("type")]
        public string Type;

        [JsonPropertyName("relevance")]
        public int Relevance;

        [JsonPropertyName("content")]
        public string Content;

        [JsonPropertyName("dataPoints")]
        public List<object> DataPoints;
    }

    public class Root
    {
        [JsonPropertyName("sorting")]
        public string Sorting;

        [JsonPropertyName("filterMapping")]
        public FilterMapping FilterMapping;

        [JsonPropertyName("filterOptions")]
        public List<object> FilterOptions;

        [JsonPropertyName("activeFilterOptions")]
        public List<object> ActiveFilterOptions;

        [JsonPropertyName("query")]
        public string Query;

        [JsonPropertyName("totalResults")]
        public int TotalResults;

        [JsonPropertyName("limit")]
        public int Limit;

        [JsonPropertyName("offset")]
        public int Offset;

        [JsonPropertyName("searchResults")]
        public List<SearchResult> SearchResults;

        [JsonPropertyName("expires")]
        public long Expires;

        [JsonPropertyName("isStale")]
        public bool IsStale;
    }

    public class SearchResult
    {
        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("type")]
        public string Type;

        [JsonPropertyName("totalResults")]
        public int TotalResults;

        [JsonPropertyName("totalResultsVariants")]
        public int TotalResultsVariants;

        [JsonPropertyName("results")]
        public List<Result> Results;
    }

}
