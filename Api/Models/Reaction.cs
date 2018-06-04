using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyx.Api.Models
{
    public class Reaction
    {
        public Guid Id { get; set; }
        public String CreatedBy { get; set; }
        public Byte Rating { get; set; }
    }
}
