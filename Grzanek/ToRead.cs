using System.ComponentModel.DataAnnotations;

namespace API
{
    public class ToRead
    {
        [Required]
        public string Tytul { get; set; }
        [Required]
        public string Autor { get; set; }

    }
}
