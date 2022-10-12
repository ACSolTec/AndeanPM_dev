using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andeanpm.Shared.Models
{
    public class InvestorReport
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;  
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [NotMapped]
        public Resume PDF { get; set; } = new();
    }
}
