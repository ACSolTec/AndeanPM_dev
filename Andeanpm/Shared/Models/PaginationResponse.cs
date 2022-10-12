using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andeanpm.Shared.Models
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; } = new();
        public MetaData MetaData { get; set; } = new();
    }
}
