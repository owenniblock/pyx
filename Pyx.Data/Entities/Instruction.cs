using System;
using System.ComponentModel.DataAnnotations;

namespace Pyx.Data.Entities
{
    public class Instruction
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public String CreatedBy { get; set; }
    }
}
