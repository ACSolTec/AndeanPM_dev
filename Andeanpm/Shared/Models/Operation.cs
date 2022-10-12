using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andeanpm.Shared.Models
{
	public class Operation
	{
		public int Id { get; set; }
		public string ImageLink { get; set; } = string.Empty;
		public string Module { get; set; } = string.Empty;
    }
}
