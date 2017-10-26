using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Rater.Api.Controllers;
using Rater.Api.Data;
using Xunit;

namespace Rater.Tests.SkillsControllerTests
{
    public class Post
    {
        [Fact]
        public void When_PostingNewItem_Returns_Item()
        {
            var dataStore = new Mock<ISkillsDataStore>();
            dataStore.Setup(ds => ds.Add(It.IsAny<Skill>())).Returns((Skill s) => s);

            var controller = new SkillsController(dataStore.Object);
            var original = new Skill();
            var result = controller.Post(original);
            Assert.Equal(result, original);
        }


        [Fact]
        public void When_PostingExistingItem_OverwritesProperties()
        {
            // This turned out an integration test rather than unit test, but I cannot think of a tidy way of
            // unit testing this

            const string originalName = "name";
            const string newName = "newName";
            const int originalRating = 10;
            const int newRating = 20;

            var dataStore = new SkillsDataStore();
            var controller = new SkillsController(dataStore);

            var original = new Skill { Name = originalName, Rating = originalRating };
            var id = controller.Post(original).Id;

            var updated = new Skill { Id = id, Name = newName, Rating = newRating };
            var result = controller.Post(updated);

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
        public void When_PostingExistingItem_AndNameIsEmpty_KeepsOriginalName()
        {
            const string originalName = "name";
            const string newName = "";
            
            var dataStore = new SkillsDataStore();
            var controller = new SkillsController(dataStore);

            var original = new Skill { Name = originalName };
            var id = controller.Post(original).Id;

            var updated = new Skill { Id = id, Name = newName };
            var result = controller.Post(updated);

            Assert.Equal(originalName, result.Name);
        }

           
        [Fact]
        public void When_PostingExistingItem_AndRatingIsZero_KeepsOriginalRating()
        {
            const int originalRating = 22;
            const int newRating = 0;
            
            var dataStore = new SkillsDataStore();
            var controller = new SkillsController(dataStore);

            var original = new Skill { Rating = originalRating };
            var id = controller.Post(original).Id;

            var updated = new Skill { Id = id, Rating = newRating };
            var result = controller.Post(updated);

            Assert.Equal(originalRating, result.Rating);
        }
    }
}