using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyx.Shared.Models
{
    public class Instruction
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public String CreatedBy { get; set; }
    }
}
