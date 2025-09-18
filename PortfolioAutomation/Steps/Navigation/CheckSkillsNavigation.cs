using Microsoft.Playwright;
using PortfolioAutomation.Abstractions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomation.Steps.Navigation
{
    public class CheckSkillsNavigation : BaseStep
    {
        public CheckSkillsNavigation(IRepository repository, IStep next = null)
            : base(repository, next) { }

        protected override async Task PerformExecute()
        {
            var page = Repository.Get<IPage>();

            Console.WriteLine("Testing Skills navigation...");
           
            await page.ClickAsync("text=Skills");
            await page.WaitForTimeoutAsync(1000);

            // Check if the skills section title is visible
            var skillsVisible = await page.IsVisibleAsync("text=Core Skills")
                                || await page.IsVisibleAsync("text=Technologies");

            if (!skillsVisible)
            {
                throw new Exception("Navigation to Skills failed. Skills section not visible.");
            }

            Console.WriteLine("Skills navigation works! Section is visible.");
        }
    }
}
