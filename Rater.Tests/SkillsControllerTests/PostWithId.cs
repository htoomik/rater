using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Rater.Api.Controllers;
using Rater.Api.Data;
using Xunit;

namespace Rater.Tests.SkillsControllerTests
{
    // These turned out as integration tests rather than unit tests, but I cannot think of a tidy way of
    // unit testing this
    public class PostWithId : Base
    {
        [Fact]
        public void When_ItemFound_OverwritesProperties()
        {
            const string originalName = "name";
            const string newName = "newName";
            const int originalRating = 10;
            const int newRating = 20;

            var dataStore = new SkillsDataStore();
            var controller = new SkillsController(dataStore);

            var original = new Skill { Name = originalName, Rating = originalRating };
            var id = controller.Post(original).Id;

            var updated = new Skill { Name = newName, Rating = newRating };
            var result = GetOkResultValue(controller.Post(id, updated));

            // Checking properties one by one is OK as long as they are few and stable.
            // For a more complex object, I'd consider using reflection to ensure that the test
            // automatically picks up any added properties.
            Assert.Equal(newName, result.Name);
            Assert.Equal(newRating, result.Rating);

            var result2 = (Skill)((OkObjectResult)controller.Get(id)).Value;
            Assert.Equal(newName, result2.Name);
            Assert.Equal(newRating, result2.Rating);
        }
   

        [Fact]
        public void When_ItemFound_AndNewNameIsEmpty_KeepsOriginalName()
        {
            const string originalName = "name";
            const string newName = "";
            
            var dataStore = new SkillsDataStore();
            var controller = new SkillsController(dataStore);

            var original = new Skill { Name = originalName };
            var id = controller.Post(original).Id;

            var updated = new Skill { Name = newName };
            var result = GetOkResultValue(controller.Post(id, updated));

            Assert.Equal(originalName, result.Name);
        }

           
        [Fact]
        public void When_ItemFound_AndNewRatingIsZero_KeepsOriginalRating()
        {
            const int originalRating = 22;
            const int newRating = 0;
            
            var dataStore = new SkillsDataStore();
            var controller = new SkillsController(dataStore);

            var original = new Skill { Rating = originalRating };
            var id = controller.Post(original).Id;

            var updated = new Skill { Rating = newRating };
            var result = GetOkResultValue(controller.Post(id, updated));

            Assert.Equal(originalRating, result.Rating);
        }


        [Fact]
        public void When_ItemNotFound_Returns_NotFound()
        {
            var dataStore = new SkillsDataStore();
            var controller = new SkillsController(dataStore);

            var id = controller.Post(new Skill()).Id;

            var result = controller.Post(id + 1, new Skill());

            Assert.IsType(typeof(NotFoundResult), result);
        }
    }
}