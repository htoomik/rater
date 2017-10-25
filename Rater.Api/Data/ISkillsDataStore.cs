using System.Collections.Generic;

namespace Rater.Api.Data
{
    public interface ISkillsDataStore
    {
        List<Skill> Get();
        Skill Get(int id);
        Skill Add(Skill value);

        int Count { get; }
    }
}