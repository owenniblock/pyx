using System;
using System.ComponentModel.DataAnnotations;

namespace Pyx.Data.Entities
{
    public class Reaction
    {
        [Key]
        public int Id { get; set; }
        public String CreatedBy { get; set; }
        public Byte Rating { get; set; }
        public Instruction Instruction { get; set; }
    }
}
