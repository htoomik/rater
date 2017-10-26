using Microsoft.AspNetCore.Mvc;

namespace Rater.Tests.SkillsControllerTests
{
    public abstract class Base
    {
        protected Skill GetOkResultValue(IActionResult result)
        {
            return (Skill)((OkObjectResult)result).Value;
        }
    }
}