using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Rater.Api.Controllers;
using Rater.Api.Data;
using Xunit;

namespace Rater.Tests.SkillsControllerTests
{
    public class Post : Base
    {
        [Fact]
        public void When_PostingItem_StoresItem()
        {
            var dataStore = new Mock<ISkillsDataStore>();
            dataStore.Setup(ds => ds.Add(It.IsAny<Skill>())).Returns((Skill s) => s);

            var controller = new SkillsController(dataStore.Object);
            var original = new Skill();
            controller.Post(original);
            
            dataStore.Verify(ds => ds.Add(It.Is<Skill>(s => s == original)));
        }


        [Fact]
        public void When_PostingItem_Returns_Item()
        {
            var dataStore = new Mock<ISkillsDataStore>();
            dataStore.Setup(ds => ds.Add(It.IsAny<Skill>())).Returns((Skill s) => s);

            var controller = new SkillsController(dataStore.Object);
            var original = new Skill();
            var result = GetOkResultValue(controller.Post(original));
            Assert.Equal(result, original);
        }


        [Fact]
        public void When_PostedItemHasId_Returns_40x()
        {
            var dataStore = new Mock<ISkillsDataStore>();
            var controller = new SkillsController(dataStore.Object);

            var original = new Skill { Id = 1 };
            var result = controller.Post(original);

            Assert.IsType(typeof(BadRequestResult), result);
        }
    }
}