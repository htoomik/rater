using System.Collections.Generic;
using System.Linq;

namespace Rater.Api.Data
{
    public class SkillsDataStore : ISkillsDataStore
    {
        private readonly List<Skill> skills = new List<Skill>();

        public int Count => skills.Count;


        public Skill Add(Skill value)
        {
            skills.Add(value);
            value.Id = skills.Count;
            return value;
        }


        public List<Skill> Get()
        {
            return new List<Skill>(skills);
        }


        public Skill Get(int id)
        {
            return skills.SingleOrDefault(s => s.Id == id);
        }
    }
}