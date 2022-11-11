using ExamProject.Api.ApiBroker;
using ExamProject.Model;

namespace ExamProject.Service;

public class ServiceFood : IServiceFood
{

    private IApiBroker api;

    public ServiceFood(IApiBroker apiBroker)
    {
        this.api = apiBroker;
    }

    public List<Data> GetFoods()
    {
        List<Data> data = new List<Data>();
        var food = SearchResult();
        foreach(var f in food[0].FoodCollection)
        {
            Data d = new Data(f.Name,f.image);
            data.Add(d);
        }
       
        return data; 
    }

    public List<SearchResults> SearchResult()
    {
        List<SearchResults> results;
        Foods result;
        try
        {
            result = api.SerializeData().Result;
           
        }
        catch(Exception ex)
        {
            Console.WriteLine("Api dan malumotlar olishda xatolik yuz berdi");
            throw;
        }
        results = result.Results;
        return results;
    }
}
