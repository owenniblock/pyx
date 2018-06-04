using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pyx.Api.Models;

namespace Pyx.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReactionController : Controller
    {
        // POST api/reaction
        [HttpPost]
        public void Post([FromBody]Reaction value)
        {
        }
    }
}
