using NUnit.Framework;
using PortfolioAutomation.Abstractions;
using PortfolioAutomation.Steps.Contact;
using PortfolioAutomation.Steps.Navigation;
using PortfolioAutomationTest.Assertions;
using System;
using System.Threading.Tasks;

namespace PortfolioAutomationTest.ContactTest
{
    [TestFixture]
    public class ContactFormTest : TestBase
    {
        [Test]
        public async Task TestContactFormFill()
        {
            try
            {
                Console.WriteLine("Starting Contact Form Fill Test...");

                IStep flow = new CheckAboutNavigation(Repository);
                flow.Chain( new AboutAssertion(Repository));
                flow.Chain(new CheckContactButton(Repository));
                flow.Chain(new ContactModalAssertion(Repository));
                flow.Chain(new FillContactForm(Repository));
                flow.Chain(new ContactFormAssertion(Repository));
                flow.Chain(new ClickContactFormSubmit(Repository));

                await flow.Execute();

                Console.WriteLine("Contact form inputs filled and validated.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Contact form fill test failed: {ex.Message}");
            }
        }
    }
}
