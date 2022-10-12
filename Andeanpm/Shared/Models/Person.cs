using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andeanpm.Shared.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string PathImage { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Subtitle { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public string Team { get; set; } = string.Empty;
        [Required]
        public int Position { get; set; }
        [NotMapped]
        public UploadImage uploadImage { get; set; } = new();
    }
}
