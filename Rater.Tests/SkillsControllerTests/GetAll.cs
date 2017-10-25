using System;
using Xunit;
using Rater.Api.Controllers;

namespace Rater.Tests
{
    public class GetAll
    {
        [Fact]
        public void When_NothingAdded_Returns_EmptyList()
        {
            var skills = new SkillsController().Get();
            Assert.Empty(skills);
        }


        [Fact]
        public void When_OneSkillAdded_Returns_OneSkill()
        {
            var controller = new SkillsController();
            controller.Post(new Skill());
            var skills = controller.Get();
            Assert.Single(skills);
        }
        

        [Fact]
        public void When_TwoSkillsAdded_Returns_TwoSkills()
        {
            var controller = new SkillsController();
            controller.Post(new Skill());
            controller.Post(new Skill());
            var skills = controller.Get();
            Assert.Collection(skills, s => {;}, s => {;}); 
        }
    }
}
