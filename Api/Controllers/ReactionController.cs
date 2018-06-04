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
    public class ReactionController : Controller
    {
        private readonly ApiContext _context;

        public ReactionController(ApiContext context)
        {
            _context = context;
        }

        // POST api/reaction
        [HttpPost]
        public void Post([FromBody]Reaction value)
        {
            var instruction = _context.Instructions.Where(x => x.Id == value.InstructionId).SingleOrDefault();

            if (instruction == null)
            {
                throw new ArgumentException("This should never happen! You should always have a valid Instruction. What're you doing?");
            }

            _context.Reactions.Add(new Data.Entities.Reaction
            {

            });
        }
    }
}
