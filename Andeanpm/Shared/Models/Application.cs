using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Andeanpm.Shared.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9+]+$", ErrorMessage = "The phone has an invalid format")]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "The Email has an invalid format")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string ApplyFor { get; set; } = string.Empty;
        public string ResumeId { get; set; } = string.Empty;
        [NotMapped]
        [Required]
        public Resume Resume { get; set; } = new();
        public DateTime ApplyDate { get; set; } = DateTime.Now;
        [NotMapped]
        [Range(typeof(bool), "true", "true", ErrorMessage = "It is required to send the data")]
        public bool Privacy { get; set; }
    }
}
