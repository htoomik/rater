using System.Collections.Generic;

namespace Rater.Api.Data
{
    public interface ISkillsDataStore
    {
        List<Skill> Get();
        Skill Get(int id);
        Skill Add(Skill value);
        Skill Update(int id, Skill value);
        void Remove(int id);

        int Count { get; }
    }
}