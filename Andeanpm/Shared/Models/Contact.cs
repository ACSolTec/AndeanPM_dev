using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andeanpm.Shared.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "The Email has an invalid format")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Text)]
        public string Subject { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Text)]
        public string Msg { get; set; } = string.Empty;
        public DateTime ContactDate { get; set; } = DateTime.Now;
    }
}
