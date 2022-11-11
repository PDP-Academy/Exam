using ExamProject.Model;
namespace ExamProject.Service;

public interface IServiceFood
{
    public List<SearchResults> SearchResult();
    public List<Data> GetFoods();
}
