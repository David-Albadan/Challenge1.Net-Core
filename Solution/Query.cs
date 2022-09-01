using System.Text.Json;
public class Query
{

    TodoItem result = RestApiQuery.loadcomic().Result;
//Resolver for Query
    
    public string Hello(string name = "David")
        => $"Hello Mr, {name}!";  
  
  
    public IEnumerable<Comic> GetComics()
    {
        var Title = new Title(result.Safe_title);
        yield return new Comic(result.Num.ToString(), Title);
        yield return new Comic(result.Year.ToString(), Title);
        // var Title = new Title("result.Safe_title");
        // yield return new Comic("result.Num.ToString()", Title);
        // yield return new Comic("result.Year.ToString()", Title);
        
    }
       
}   
 public record Title(string safename);

 public record Comic(string Date, Title Comics);







