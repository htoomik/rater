using Microsoft.AspNetCore.Mvc;
using Moq;
using Rater.Api;
using Rater.Api.Controllers;
using Rater.Api.Data;
using Xunit;

namespace Rater.Tests.SkillsControllerTests
{
    public class Delete : Base
    {
        [Fact]
        public void When_DeletingItem_RemovesItem()
        {
            const int id = 1;

            var dataStore = new Mock<ISkillsDataStore>();
            var controller = new SkillsController(dataStore.Object);

            controller.Delete(id);
            dataStore.Verify(ds => ds.Remove(It.Is<int>(s => s == id)));
        }


        [Fact]
        public void When_ItemNotFound_Returns_NotFound()
        {
            const int id = 1;

            var dataStore = new Mock<ISkillsDataStore>();
            var controller = new SkillsController(dataStore.Object);
            dataStore.Setup(ds => ds.Remove(id)).Throws(new NotFoundException());

            var result = controller.Delete(id);

            Assert.IsType(typeof(NotFoundResult), result);
        }
    }
}