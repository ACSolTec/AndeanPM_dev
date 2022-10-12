using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andeanpm.Shared.Models
{
    public class SmptSettings
    {
        public string Server { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty;
        public string NameInfo { get; set; } = string.Empty; 
        public string UsernameInfo { get; set; } = string.Empty;
        public string PasswordInfo { get; set; } = string.Empty;
    }
}
