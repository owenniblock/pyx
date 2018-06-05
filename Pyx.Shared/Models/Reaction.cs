using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyx.Shared.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public String CreatedBy { get; set; }
        public Byte Rating { get; set; }
        public int InstructionId { get; set; }
    }
}
