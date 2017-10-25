using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rater.Api.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        private List<Skill> skills = new List<Skill>();


        // GET api/skills
        [HttpGet]
        public List<Skill> Get()
        {
            return new List<Skill>(skills);
        }

        // GET api/skills/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = skills.SingleOrDefault(s => s.Id == id);
            if (item == null)
                return NotFound();
            else
                return Ok(item);
        }

        // POST api/skills
        [HttpPost]
        public Skill Post([FromBody]Skill value)
        {
            skills.Add(value);
            value.Id = skills.Count;
            return value;
        }

        // PUT api/skills/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/skills/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
