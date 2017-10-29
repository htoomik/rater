using Rater.Api;
using Rater.Api.Data;
using Xunit;

namespace Rater.Tests.SkillsDataStoreTests
{
    [Collection("SkillsDataStoreTests")]
    public class Remove
    {
        [Fact]
        public void When_ValidId_Expect_RemovesValue()
        {
            var dataStore = new SkillsDataStore();
            var result = dataStore.Add(new Skill());
            var id = result.Id;

            dataStore.Remove(id);

            Assert.Throws<NotFoundException>(() => dataStore.Get(id));
        }


        [Fact]
        public void When_InvalidId_Expect_Throws()
        {
            var dataStore = new SkillsDataStore();

            Assert.Throws<NotFoundException>(() => dataStore.Remove(1));         
        }
    }
}