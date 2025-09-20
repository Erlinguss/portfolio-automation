using NUnit.Framework;
using PortfolioAutomation.Abstractions;
using PortfolioAutomation.Steps.Contact;
using PortfolioAutomationTest.Assertions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomationTest.ContactTest
{
    [TestFixture]
    public class ContactButtonTest : TestBase
    {
        [Test]
        public async Task TestContactModal()
        {
            try
            {
                Console.WriteLine("Starting Contact Modal Test...");

                IStep flow = new CheckContactButton(Repository);
                flow.Chain(new ContactModalAssertion(Repository));

                await flow.Execute();

                Console.WriteLine("Contact modal test executed successfully.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Contact modal test failed: {ex.Message}");
            }
        }
    }
}
