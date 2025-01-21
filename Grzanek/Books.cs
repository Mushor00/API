using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API
{
    public class Books
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public DateOnly Data { get; set; }
        [Required]
        public string? Tytul { get; set; }
        [Required]
        public string? Autor { get; set; }

    }
}
