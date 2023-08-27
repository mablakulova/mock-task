using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class LinkEntity : Entity
    {
        [Required(ErrorMessage = "Url is a required field.")]
        public string Url { get; set; }

        [Required(ErrorMessage = "ShortUrl is a required field.")]
        public string ShortUrl { get; set; }
    }
}
