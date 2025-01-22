using Microsoft.AspNetCore.Mvc;
using API.Services;
using Microsoft.Data.SqlClient;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly IBooksService _books;


        [HttpGet]
        [Route("allbooks")]
        public async Task<IActionResult> GetBooksTask(Books book)
        {
            try
            {
                var result = await _books.GetBooks();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        [Route("addbooks")]
        public async Task<IActionResult> AddBooksTask(Books book)
        {
            try
            {
                var connectionString = "TODO!;";
                var connection = new SqlConnection(connectionString);
                connection.Open();
                var bookID = book.ID;
                var properTytul = book.Tytul!.Replace("'", "\"");
                var properAutor = book.Autor!.Replace("'", "\"");
                var query = $"INSERT INTO Books VALUES ('{bookID}', {book.Data}, '{properTytul}', '{properAutor}')";
                var commmand = new SqlCommand(query, connection);
                var id = commmand.ExecuteNonQuery();
                connection.Close();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }


        [HttpDelete]
        [Route("deletebooks")]
        public async Task<IActionResult> DeleteBooksTask(Books book)
        {
            try
            {
                var connectionString = "TODO!;";
                var connection = new SqlConnection(connectionString);
                connection.Open();
                var properTytul = book.Tytul!.Replace("'", "\"");
                var query = $"DELETE FROM Books WHERE Tytul IS LIKE '{properTytul}'";
                var commmand = new SqlCommand(query, connection);
                var id = commmand.ExecuteNonQuery();
                connection.Close();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
