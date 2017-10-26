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
        public Skill Post([FromBody]Skill value)
        {
            if (value.Id > 0)
            {
                var id = value.Id;
                var existing = dataStore.Get(id);
                if (existing != null)
                {
                    if (!string.IsNullOrEmpty(value.Name))
                        existing.Name = value.Name;
                    if (value.Rating != 0)
                        existing.Rating = value.Rating;
                    return existing;
                }
            }
            dataStore.Add(value);
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
