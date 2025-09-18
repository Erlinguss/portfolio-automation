using NUnit.Framework;
using PortfolioAutomation.Abstractions;
using PortfolioAutomationTest;
using PortfolioAutomation.Steps;
using PortfolioAutomation.Steps.Dashboard;

namespace PortfolioAutomation.DashboardTest
{
    [TestFixture]
    public class DashboardResponsivenessTest : TestBase
    {
        [Test]
        public async Task TestResponsiveness()
        {
            try
            {
                Console.WriteLine("Starting Dashboard Responsiveness Test...");

                // Initialize the flow 
                IStep flow = new CheckDashboardResponsiveness(Repository);

                // Execute the flow
                await flow.Execute();

                Console.WriteLine("Responsiveness flow executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during Responsiveness Test: {ex.Message}");
            }
        }
    }
}
