using Microsoft.AspNetCore.Mvc;
using API.Services;
using Microsoft.Data.SqlClient;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToReadController : ControllerBase
    {

        private readonly IToReadService _toRead;


        [HttpGet]
        [Route("readtobooks")]
        public async Task<IActionResult> GetToRead([FromQuery] int ID)
        {
            try
            {
                var result = await _toRead.GetToRead(ID);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        [Route("addtoreadbook")]
        public async Task<IActionResult> AddToRead(ToRead toRead)
        {
            try
            {
                var connectionString = "TODO!;";
                var connection = new SqlConnection(connectionString);
                connection.Open();
                var toReadId = toRead.ID;
                var properTytul = toRead.Tytul!.Replace("'", "\"");
                var properAutor = toRead.Autor!.Replace("'", "\"");
                var query = $"INSERT INTO ToRead VALUES ('{toReadId}', '{properTytul}', '{properAutor}')";
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
