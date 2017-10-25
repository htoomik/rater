using Microsoft.AspNetCore.Mvc;
using Rater.Api.Controllers;
using Xunit;

namespace Rater.Tests
{
    public class Get
    {
        [Fact]
        public void When_ValidId_Returns_Item_WithThatId()
        {
            var controller = new SkillsController();
            controller.Post(new Skill());
            
            var result = controller.Get(1);
            
            Assert.IsType(typeof(OkObjectResult), result);
            var okResult = (OkObjectResult)result;
            var skill = (Skill)okResult.Value;
            Assert.Equal(skill.Id, 1);
        }


        [Fact]
        public void When_InvalidId_Returns_NotFound()
        {
            var controller = new SkillsController();
            
            var result = controller.Get(1);

            Assert.IsType(typeof(NotFoundResult), result);
        }
    }
}