using System.Collections.Generic;
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
            try
            {
                var item = dataStore.Get(id);
                return Ok(item);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
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
        [Route("api/skills/{id}")]
        [HttpPost]
        public IActionResult Post(int id, [FromBody]Skill value)
        {
            try 
            {
                var existing = dataStore.Get(id);
                if (!string.IsNullOrEmpty(value.Name))
                    existing.Name = value.Name;
                if (value.Rating != 0)
                    existing.Rating = value.Rating;
                return Ok(existing);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }


        // PUT api/skills/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Skill value)
        {
            try 
            {
                var result = dataStore.Update(id, value);
                return Ok(value);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }


        // DELETE api/skills/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                dataStore.Remove(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
