using Moq;
using Rater.Api.Controllers;
using Rater.Api.Data;
using Xunit;

namespace Rater.Tests
{
    public class Post
    {
        [Fact]
        public void When_PostingItem_Returns_Item()
        {
            var dataStore = new Mock<ISkillsDataStore>();
            dataStore.Setup(ds => ds.Add(It.IsAny<Skill>())).Returns((Skill s) => s);

            var controller = new SkillsController(dataStore.Object);
            var original = new Skill();
            var result = controller.Post(original);
            Assert.Equal(result, original);
        }
    }
}