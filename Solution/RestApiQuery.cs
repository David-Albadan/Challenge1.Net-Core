using System;

public interface IRestApiQuery
{
    List<TodoItem> Item { get; }
}


public class RestApiQuery : IRestApiQuery
{
    public List<TodoItem> Item { get; private set; }


    public async static Task<TodoItem> loadcomic()
    {

        string url = "https://xkcd.com/1/info.0.json"; // Public Web API to consult comics

        using (HttpResponseMessage response = await RestService.ApiClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                TodoItem ComicValues = await response.Content.ReadAsAsync<TodoItem>();
                return ComicValues;

            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }


    }
}