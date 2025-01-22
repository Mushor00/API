using System.Net.Http.Json;
using System.Threading.Tasks;
using API;

public class BooksService
{
    private readonly HttpClient _httpClient;

    public BooksService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Books>> GetBooks()
    {
        return await _httpClient.GetFromJsonAsync<List<Books>>("/Books/allbooks");
    }

    public async Task<List<ToRead>> GetToReadBooks()
    {
        return await _httpClient.GetFromJsonAsync<List<ToRead>>("/ToRead");
    }

    public async Task AddBook(Books book)
    {
        await _httpClient.PostAsJsonAsync("/Books/addbooks", book);
    }

    public async Task AddToReadBook(ToRead book)
    {
        await _httpClient.PostAsJsonAsync("/ToRead", book);
    }

    public async Task DeleteBook(Books book)
    {
        await _httpClient.DeleteAsync($"/Books/deletebooks?Tytul={book.Tytul}");
    }
}