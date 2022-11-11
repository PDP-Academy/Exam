using ExamProject.Model;
namespace ExamProject.Api.ApiBroker;

public interface IApiBroker
{
    Task<string> GetDataFromApi();
    Task<Foods> SerializeData();
}
