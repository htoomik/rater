using Rater.Api;
using Rater.Api.Data;
using Xunit;

namespace Rater.Tests.SkillsDataStoreTests
{
    [Collection("SkillsDataStoreTests")]
    public class Update
    {
        [Fact]
        public void When_ValidId_Expect_ReplacesValue()
        {
            var dataStore = new SkillsDataStore();
            var skill1 = dataStore.Add(new Skill());
            var skill2 = new Skill();
            var id = skill1.Id;
            
            dataStore.Update(id, skill2);

            var actual = dataStore.Get(id);
            Assert.Equal(skill2, actual);
        }


        [Fact]
        public void When_ValidId_Expect_Returns_ItemWithId()
        {
            var dataStore = new SkillsDataStore();
            var skill1 = dataStore.Add(new Skill());
            var skill2 = new Skill();
            var id = skill1.Id;
            
            var actual = dataStore.Update(id, skill2);

            Assert.Equal(skill2.Id, id);
        }


        [Fact]
        public void When_InvalidId_Expect_Throws()
        {
            var dataStore = new SkillsDataStore();
            const int id = 1;

            Assert.Throws<NotFoundException>(() => dataStore.Update(id, new Skill()));
        }
    }
}