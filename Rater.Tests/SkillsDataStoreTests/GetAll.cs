using System;
using Xunit;
using Rater.Api.Data;

namespace Rater.Tests.SkillsDataStoreTests
{
    [Collection("SkillsDataStoreTests")]
    public class GetAll
    {
        [Fact]
        public void When_NothingAdded_Returns_EmptyList()
        {
            var skills = new SkillsDataStore().Get();
            Assert.Empty(skills);
        }


        [Fact]
        public void When_OneSkillAdded_Returns_OneSkill()
        {
            var dataStore = new SkillsDataStore();
            dataStore.Add(new Skill());
            var skills = dataStore.Get();
            Assert.Single(skills);
        }
        

        [Fact]
        public void When_TwoSkillsAdded_Returns_TwoSkills()
        {
            var dataStore = new SkillsDataStore();
            dataStore.Add(new Skill());
            dataStore.Add(new Skill());
            var skills = dataStore.Get();
            Assert.Collection(skills, s => {;}, s => {;}); 
        }
    }
}
