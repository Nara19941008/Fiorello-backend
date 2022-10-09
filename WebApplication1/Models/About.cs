using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class About : BaseEntity
    {
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
