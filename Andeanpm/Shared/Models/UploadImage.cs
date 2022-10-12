using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andeanpm.Shared.Models
{
	public class UploadImage
	{
        public string NewImageFileExtension { get; set; } = string.Empty;
        // Base64 is basically a string that represents binary
        public string NewImageBase64Content { get; set; } = string.Empty;
        public string OldIamge { get; set; } = string.Empty;
        public string Folder { get; set; } = string.Empty;
    }
}
