using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class HeroesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            var heroes = new List<Hero>
            {
                new Hero {Id = 1, Name = "Alex"},
                new Hero {Id = 2, Name = "David"},
                new Hero {Id = 3, Name = "Vu"},
                new Hero {Id = 4, Name = "Trump"},
                new Hero {Id = 5, Name = "Clinton"},
                new Hero {Id = 6, Name = "Obama"},
                new Hero {Id = 7, Name = "Mark"},
                new Hero {Id = 8, Name = "Mitty"},
                new Hero {Id = 9, Name = "Shaasi"}
            };
            return heroes;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
