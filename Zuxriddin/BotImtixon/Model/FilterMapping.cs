using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BotImtixon.Model;

public class FilterMapping
{
    
}

public class Result
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Link { get; set; }
    public string Type { get; set; }
    public int Relevance { get; set; }
    public string Content { get; set; }

    [JsonPropertyName("dataPoints")]
    public List<object> DataPoints { get; set; }
}

public class Root
{
    public string Sorting { get; set; }

    [JsonPropertyName("filterMapping")]
    public FilterMapping FilterMapping { get; set; }

    [JsonPropertyName("filterOptions")]
    public List<object> FilterOptions { get; set; }

    [JsonPropertyName("activeFilterOptions")]
    public List<object> ActiveFilterOptions { get; set; }
    public string Query { get; set; }
    public int TotalResults { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }

    [JsonPropertyName("searchResults")]
    public List<SearchResult> SearchResults { get; set; }
    public long Expires { get; set; }
    public bool IsStale { get; set; }
    public override string ToString()
    {
        return  $"{FilterMapping}";
    }
}

public class SearchResult
{
    public string Name { get; set; }
    public string Type { get; set; }

    [JsonPropertyName("TotalResults")]
    public int TotalResults { get; set; }

    [JsonPropertyName("totalResultsVariants")]
    public int TotalResultsVariants { get; set; }
    public List<Result> Results { get; set; }
}