using Microsoft.AspNetCore.Mvc;
using Rater.Api.Controllers;
using Rater.Api.Data;
using Xunit;

namespace Rater.Tests.SkillsControllerTests
{
    public class Put : Base
    {
        [Fact]
        public void When_ValidId_StoresItem()
        {
            var original = new Skill { Name = "original", Rating = 1 };
            
            var dataStore = new SkillsDataStore();
            var controller = new SkillsController(dataStore);

            var id = GetOkResultValue(controller.Post(original)).Id;

            var updated = new Skill { Name = "updated", Rating = 2 };
            controller.Put(id, updated);
            
            var result = GetOkResultValue(controller.Get(id));
            Assert.Equal(updated.Name, result.Name);
            Assert.Equal(updated.Rating, result.Rating);
        }


        [Fact]
        public void When_InvalidId_Returns_NotFound()
        {
            const int id = 1;
            var dataStore = new SkillsDataStore();
            var controller = new SkillsController(dataStore);

            var updated = new Skill { Name = "updated", Rating = 2 };
            var result = controller.Put(id, updated);
            
            Assert.IsType(typeof(NotFoundResult), result);
        }}
}