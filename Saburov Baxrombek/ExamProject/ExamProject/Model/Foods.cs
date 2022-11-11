
using System.Text.Json.Serialization;

namespace ExamProject.Model;
[Serializable]
public class Foods
{
    [JsonPropertyName("searchResults")]
   public List<SearchResults> Results { get; set; }
}

public class SearchResults
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("totalResults")]
    public int TotalResults { get; set; }
    [JsonPropertyName("results")]
    public List<Food> FoodCollection { get; set; }

}
public class Food
{
    [JsonPropertyName("id")]

    public int Id { get; set; }
    [JsonPropertyName("name")]

    public string Name { get; set; }
    public string type { get; set; }
    

    public string image { get; set; }
    public string link { get; set; }
    public int relevance { get;  set; }
    public string content { get; set; }
        
}
