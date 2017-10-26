using Microsoft.AspNetCore.Mvc;
using Moq;
using Rater.Api.Controllers;
using Rater.Api.Data;
using Xunit;

namespace Rater.Tests.SkillsControllerTests
{
    public class Get : Base
    {
        [Fact]
        public void When_ValidId_Returns_Item()
        {
            const int id = 1;
            var expected = new Skill();

            var dataStore = new Mock<ISkillsDataStore>();
            dataStore.Setup(ds => ds.Get(id)).Returns(expected);

            var controller = new SkillsController(dataStore.Object);

            var result = controller.Get(id);

            var actual = GetOkResultValue(result);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void When_InvalidId_Returns_NotFound()
        {
            const int id = 1;

            var dataStore = new Mock<ISkillsDataStore>();
            dataStore.Setup(ds => ds.Get(id)).Returns<Skill>(null);

            var controller = new SkillsController(dataStore.Object);
            
            var result = controller.Get(id);

            Assert.IsType(typeof(NotFoundResult), result);
        }
    }
}