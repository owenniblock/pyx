using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pyx.Api.Models;
using Pyx.Data;

namespace Pyx.Api.Controllers
{
    [Route("api/[controller]")]
    public class InstructionController : Controller
    {
        private readonly ApiContext _context;

        public InstructionController(ApiContext context)
        {
            _context = context;
        }

        // GET api/instruction/{id}
        [HttpGet]
        public Instruction Get(int id)
        {
            var instruction = _context.Instructions.Where(x => x.Id == id).SingleOrDefault();

            if (instruction == null)
            {
                return null;
            }

            return new Instruction
            { CreatedBy = instruction.CreatedBy, CreatedAt = instruction.CreatedAt, Title = instruction.Title,
                Description = instruction.Description, Id = id,
            };
        }

        // POST api/instruction
        [HttpPost]
        public void Post([FromBody]Instruction value)
        {
            _context.Instructions.Add(new Data.Entities.Instruction
            {
                CreatedAt = DateTime.Now,
                CreatedBy = value.CreatedBy,
                Title = value.Title,
                Description = value.Description,
                Id = value.Id
            });
        }
    }
}
