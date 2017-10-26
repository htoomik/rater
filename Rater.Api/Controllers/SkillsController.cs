using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rater.Api.Data;

namespace Rater.Api.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        private readonly ISkillsDataStore dataStore;

        public SkillsController(ISkillsDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        // GET api/skills
        [HttpGet]
        public List<Skill> Get()
        {
            return dataStore.Get();
        }

        // GET api/skills/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = dataStore.Get(id);
            if (item == null)
                return NotFound();
            else
                return Ok(item);
        }

        // POST api/skills
        [HttpPost]
        public IActionResult Post([FromBody]Skill value)
        {
            // If you want to POST an update to an existing item, use the overload with id parameter
            if (value.Id > 0)
                return BadRequest();

            dataStore.Add(value);
            return Ok(value);
        }


        // POST api/skills/5
        [HttpPost]
        public IActionResult Post(int id, [FromBody]Skill value)
        {
            var existing = dataStore.Get(id);
            if (existing != null)
            {
                if (!string.IsNullOrEmpty(value.Name))
                    existing.Name = value.Name;
                if (value.Rating != 0)
                    existing.Rating = value.Rating;
                return Ok(existing);
            }
            return NotFound();
        }


        // PUT api/skills/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Skill value)
        {
            var result = dataStore.Update(id, value);
            if (result != null)
                return Ok(value);
            return NotFound();
        }


        // DELETE api/skills/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
