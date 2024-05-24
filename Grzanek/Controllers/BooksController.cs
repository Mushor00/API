using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Grzanek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly string _jsonFilePath;
        private readonly IWebHostEnvironment _environment;

        public BooksController(IWebHostEnvironment environment)
        {
            _environment = environment;
            _jsonFilePath = Path.Combine(_environment.ContentRootPath, "Data", "Books.json");
        }

        [HttpGet(Name = "GetBooks")]
        public IActionResult GetBooks()
        {
            List<Books> books = LoadBooksFromJson();
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpPost(Name = "AddBook")]
        public IActionResult AddBook(Books book)
        {
            List<Books> books = LoadBooksFromJson() ?? new List<Books>();
            books.Add(book);
            SaveBooksToJson(books);
            return Ok();
        }

        private List<Books> LoadBooksFromJson()
        {
            try
            {
                using (StreamReader reader = new StreamReader(_jsonFilePath))
                {
                    string json = reader.ReadToEnd();
                    return JsonSerializer.Deserialize<List<Books>>(json);
                }
            }
            catch (IOException)
            {
                return null;
            }
        }

        private void SaveBooksToJson(List<Books> books)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(books, Formatting.Indented);
                System.IO.File.WriteAllText(_jsonFilePath, jsonString);
            }
            catch (IOException)
            {
                
            }
        }
    }
}
