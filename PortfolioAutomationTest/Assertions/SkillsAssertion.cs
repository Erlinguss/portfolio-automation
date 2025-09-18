using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace PortfolioAutomationTest
{
    public class SkillsAssertion : BaseStep
    {
        public SkillsAssertion(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            Console.WriteLine("Asserting Skills Section...");

            var page = Repository.Get<IPage>();
            await page.WaitForLoadStateAsync();

            var skillsLocator = page.Locator("h2:has-text('Core Skills & Technologies')");
            await Expect(skillsLocator).ToBeVisibleAsync();

            Console.WriteLine("Skills section is visible.");
        }
    }
}
