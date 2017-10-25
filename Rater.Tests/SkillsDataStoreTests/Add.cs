using Rater.Api.Data;
using Xunit;

namespace Rater.Tests.SkillsDataStoreTests
{
    [Collection("SkillsDataStoreTests")]
    public class Add
    {
        [Fact]
        public void When_AddingFirstItem_Returns_ItemWithId_1()
        {
            var dataStore = new SkillsDataStore();
            var result = dataStore.Add(new Skill());
            Assert.Equal(1, result.Id);
        }


        [Fact]
        public void When_AddingMultipleItems_Returns_ItemsWithIncreasingId()
        {
            var dataStore = new SkillsDataStore();

            for (var i = 0; i < 5; i++)
            {
                var result = dataStore.Add(new Skill());
                Assert.Equal(i + 1, result.Id);
            }            
        }
    }
}