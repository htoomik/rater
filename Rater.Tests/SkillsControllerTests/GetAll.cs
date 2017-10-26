using System;
using Xunit;
using Rater.Api.Controllers;
using Rater.Api.Data;
using Moq;
using System.Collections.Generic;

namespace Rater.Tests.SkillsControllerTests
{
    public class GetAll : Base
    {
        [Fact]
        public void When_NoSkills_Returns_EmptyList()
        {
            var dataStore = new Mock<ISkillsDataStore>();
            dataStore.Setup(ds => ds.Get()).Returns(new List<Skill>());

            var controller = new SkillsController(dataStore.Object);

            var skills = controller.Get();
            
            Assert.Empty(skills);
        }


        [Fact]
        public void When_HasSkills_Returns_Skills()
        {
            var dataStore = new Mock<ISkillsDataStore>();
            dataStore.Setup(ds => ds.Get()).Returns(new List<Skill> { new Skill() });

            var controller = new SkillsController(dataStore.Object);

            controller.Post(new Skill());
            var skills = controller.Get();
            Assert.Single(skills);
        }
    }
}
