using Rater.Api.Controllers;
using Xunit;

namespace Rater.Tests
{
    public class Post
    {
        [Fact]
        public void When_PostingFirstItem_Returns_ItemWithId_1()
        {
            var controller = new SkillsController();
            var result = controller.Post(new Skill());
            Assert.Equal(1, result.Id);
        }


        [Fact]
        public void When_PostingMultipleItems_Returns_ItemsWithIncreasingId()
        {
            var controller = new SkillsController();

            for (var i = 0; i < 5; i++)
            {
                var result = controller.Post(new Skill());
                Assert.Equal(i + 1, result.Id);
            }            
        }
    }
}