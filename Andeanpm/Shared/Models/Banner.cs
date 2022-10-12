using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andeanpm.Shared.Models
{
	public class Banner
	{
		public int Id { get; set; }
		public string Module { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
		[NotMapped]
		public UploadImage uploadImage { get; set; } = new();
	}
}
