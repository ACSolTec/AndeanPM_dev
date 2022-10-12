using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andeanpm.Shared.Models
{
	public class NewDTO
	{
        public int Id { get; set; }
        public string PKNews { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Subtitle { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        public string PDFURL { get; set; } = string.Empty;
        public DateTime DateNews { get; set; } = DateTime.Now;
        public int Year { get; set; } = DateTime.Now.Year;
        [NotMapped]
        public Resume PDF { get; set; } = new();
    }
}
