using Microsoft.AspNetCore.Mvc;
using Moq;
using Rater.Api;
using Rater.Api.Controllers;
using Rater.Api.Data;
using Xunit;

namespace Rater.Tests.SkillsDataStoreTests
{
    [Collection("SkillsDataStoreTests")]
    public class Get
    {
        [Fact]
        public void When_ValidId_Returns_Item_WithThatId()
        {
            var dataStore = new SkillsDataStore();
            dataStore.Add(new Skill());
            
            var skill = dataStore.Get(1);

            Assert.Equal(skill.Id, 1);
        }


        [Fact]
        public void When_InvalidId_Expect_Throws()
        {
            var dataStore = new SkillsDataStore();

            Assert.Throws<NotFoundException>(() => dataStore.Get(1));
        }
    }
}