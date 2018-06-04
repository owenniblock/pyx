using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pyx.Api.Models;

namespace Pyx.Api.Controllers
{
    [Route("api/[controller]")]
    public class InstructionController : Controller
    {
        // GET api/instruction
        [HttpGet]
        public Instruction Get()
        {
            return new Instruction { CreatedBy = "Owen", CreatedAt = DateTime.Now, Title = "Stub Instruction",
                Description = "Stub Instruction Description", Id = Guid.NewGuid(),
            };
        }

        // POST api/instruction
        [HttpPost]
        public void Post([FromBody]Instruction value)
        {
        }
    }
}
