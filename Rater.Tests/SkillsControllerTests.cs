using System;
using Xunit;
using Rater.Api.Controllers;

namespace Rater.Tests
{
    public class SkillsControllerTests
    {
        [Fact]
        public void Test1()
        {
            var controller = new SkillsController();
            var skill = controller.Get(1);
            Assert.Equal(skill, "value");
        }
    }
}
