using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Grzanek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToReadController : Controller
    {
        private readonly string _jsonFilePath;
        private readonly IWebHostEnvironment _enviromental;

        public ToReadController(IWebHostEnvironment enviromental)
        {
            _enviromental = enviromental;
            _jsonFilePath = Path.Combine(_enviromental.ContentRootPath, "Data", "ToRead.json");
        }

        [HttpGet(Name = "GetToRead")]
        public IActionResult GetToRead()
        {
            List<ToRead> booksToRead = LoadToReadFromJson();
            if (booksToRead == null)
            {
                return NotFound();
            }

            return Ok(booksToRead);
        }

        [HttpPost(Name = "AddToRead")]
        public IActionResult AddToRead(ToRead toRead)
        {
            List<ToRead> booksToRead = LoadToReadFromJson() ?? new List<ToRead>();
            booksToRead.Add(toRead);
            SaveToReadToJson(booksToRead);
            return Ok();
        }

        private List<ToRead> LoadToReadFromJson()
        {
            try
            {
                using (StreamReader reader = new StreamReader(_jsonFilePath))
                {
                    string json = reader.ReadToEnd();
                    return JsonSerializer.Deserialize<List<ToRead>>(json);
                }
            }
            catch (IOException)
            {
                return null;
            }
        }

        private void SaveToReadToJson(List<ToRead> booksToRead)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(booksToRead);
                System.IO.File.WriteAllText(_jsonFilePath, jsonString);
            }
            catch (IOException)
            {
        
            }
        }
    }
}