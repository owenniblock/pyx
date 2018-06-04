using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pyx.Api.Models;

namespace Pyx.Api.Controllers
{
    [Route("api/[controller]")]
    public class PerformanceController : Controller
    {
        // GET api/performance
        [HttpGet]
        public Performance Get()
        {
            return new Performance { Date = DateTime.Now, Title = "Stub Performance", Id = Guid.NewGuid() };
        }

        // POST api/performance
        [HttpPost]
        public void Post([FromBody]Performance value)
        {
        }
    }
}
