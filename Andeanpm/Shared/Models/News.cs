using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andeanpm.Shared.Models
{
    public class News
    {
        public int Id { get; set; }
        public string PKNews { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string PDFURL { get; set; } = string.Empty;
        public DateTime DateNews { get; set; } = DateTime.Now;
        public int Year { get; set; } = DateTime.Now.Year;
        [NotMapped]
        public ShareButtons shareButtons { get; set; }
        [NotMapped]
        public string dateJson { get; set; }

        [NotMapped]
        [Required]
        public Resume PDF { get; set; } = new();
    }

    public class ShareButtons
    {
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string WhatsappUrl { get; set; }
        public ShareButtons() { }
        public ShareButtons(string text, string url)
        {
            TwitterUrl = $"https://twitter.com/intent/tweet?url={url}&text={text}";
            LinkedInUrl = $"https://www.linkedin.com/shareArticle?url={url}&title={text}";
            FacebookUrl = $"https://www.facebook.com/sharer/sharer.php?u={url}";
            WhatsappUrl = $"https://web.whatsapp.com/send?text={text}{url}";
        }
    }
}
