using System.ComponentModel.DataAnnotations;

namespace Andeanpm.Shared.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        [Required]
        public long Maximum { get; set; }
        public long Minimum { get; set; }
        public long Val { get; set; }

    }
}
