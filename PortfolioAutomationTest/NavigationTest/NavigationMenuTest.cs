using NuGet.Protocol.Core.Types;
using NUnit.Framework;
using PortfolioAutomation.Abstractions;
using PortfolioAutomation.Steps.Navigation;
using PortfolioAutomationTest;
using PortfolioAutomationTest.Assertions;

namespace PortfolioAutomationTest.NavigationTest
{
    [TestFixture]
    public class NavigationMenuTest : TestBase
    {
        [Test]
        public async Task TestNavigationMenu()
        {
            try
            {
                Console.WriteLine("Starting Navigation Menu Test...");

                IStep flow = new CheckHomeNavigation(Repository);
                flow.Chain(new HomeAssertion(Repository));
                flow.Chain(new CheckAboutNavigation(Repository));
                flow.Chain(new AboutAssertion(Repository));
                flow.Chain(new CheckProjectsNavigation(Repository));
                flow.Chain(new ProjectsAssertion(Repository));
                flow.Chain(new CheckSkillsNavigation(Repository));

                await flow.Execute();

                Console.WriteLine("Navigation menu flow executed successfully.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Navigation menu test failed: {ex.Message}");
            }
        }
    }
}
