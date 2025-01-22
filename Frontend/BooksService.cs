using System.Net.Http.Json;
using API;
using API.Services;

namespace Frontend.Services
{
    public class BooksService : IBooksService
    {
        private readonly HttpClient _httpClient;

        public BooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Books>> GetBooks()
        {
            return await _httpClient.GetFromJsonAsync<List<Books>>("/readbooks");
        }

        public async Task AddBooks(Books book)
        {
            await _httpClient.PostAsJsonAsync("api/books", book);
        }

        public async Task DeleteBooks(Books book)
        {
            await _httpClient.DeleteAsync($"api/books/{book}");
        }
    }
}