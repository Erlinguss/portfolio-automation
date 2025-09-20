using NUnit.Framework;
using PortfolioAutomation.Abstractions;
using PortfolioAutomation.Steps.DownloadCV;
using PortfolioAutomationTest.Assertions;

namespace PortfolioAutomationTest.DownloadCVTest
{
    [TestFixture]
    public class DownloadCVButtonTest : TestBase
    {
        [Test]
        public async Task TestDownloadCV()
        {
            try
            {
                Console.WriteLine("Starting Download CV Test...");

                IStep flow = new CheckDownloadCV(Repository);
                      flow.Chain(new DownloadCVAssertion(Repository));

                await flow.Execute();

                Console.WriteLine("Download CV Test executed successfully.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Download CV Test failed: {ex.Message}");
            }
        }
    }
}
