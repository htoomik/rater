using System.Collections.Generic;
using System.Linq;

namespace Rater.Api.Data
{
    public class SkillsDataStore : ISkillsDataStore
    {
        private readonly Dictionary<int, Skill> skills = new Dictionary<int, Skill>();

        public int Count => skills.Count;


        public Skill Add(Skill value)
        {
            value.Id = skills.Count + 1;
            skills.Add(value.Id, value);
            return value;
        }


        public List<Skill> Get()
        {
            return new List<Skill>(skills.Values);
        }


        public Skill Get(int id)
        {
            if (!skills.ContainsKey(id))
                return null;
            return skills[id];
        }
    }
}