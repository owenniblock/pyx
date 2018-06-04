using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyx.Api.Models
{
    public class Performance
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public DateTime Date { get; set; }
    }
}
