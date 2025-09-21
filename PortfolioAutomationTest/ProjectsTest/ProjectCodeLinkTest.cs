using NUnit.Framework;
using PortfolioAutomation.Steps.Navigation;
using PortfolioAutomation.Abstractions;
using PortfolioAutomation.Steps.Projects;
using PortfolioAutomationTest.Assertions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomationTest.ProjectsTest
{
    [TestFixture]
    public class ProjectCodeLinkTest : TestBase
    {
        [Test]
        public async Task TestProjectCodeLink()
        {
            try
            {
                Console.WriteLine("Starting Featured Project Code Link Test...");

                IStep flow = new CheckProjectsNavigation(Repository);
                flow.Chain(new ProjectsAssertion(Repository));
                flow.Chain(new CheckProjectCodeLink(Repository));
                flow.Chain(new ProjectCodeLinkAssertion(Repository));

                await flow.Execute();

                Console.WriteLine("Featured Project Code Link Test completed successfully.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Featured Project Code Link Test failed: {ex.Message}");
            }
        }
    }
}

