using Autofac;
using Dependency_Injection;
using Microsoft.Playwright;
using SelfServicePortal.Specs.PageObjects;
using TechTalk.SpecFlow;

namespace SelfServicePortal.Specs.Steps
{
    [Binding]
    public class TestPageFlowBetweenTwoObjects
    {
        private readonly IBrowser _browser;
        private readonly GooglePage _googlePage;
        private readonly SampleTestPage _sampleTestPage;

        public TestPageFlowBetweenTwoObjects()
        {
            var container = ContainerConfig.Configure();

            _browser = container.Resolve<IBrowser>();//browser;
            _googlePage = container.Resolve<GooglePage>(); //loginPage;
            _sampleTestPage = container.Resolve<SampleTestPage>();//projectsPage;
        }
        [Given(@"the user is on the Google homepage")]
        public async Task GivenUserOpensGooglePage()
        {
            await _googlePage.CreatePageAsync("https://www.google.com/");
        }
        [When(@"the user searches for (.*) and navigates to the website")]
        public async Task WhenUserSerachesForUrlAndGoesThere(string url)
        {
            await _googlePage.TypeInSearchBar(url);
            await _googlePage.ClickSearch();


        }
        [Then("the user clicks the button on the page")]
        public async Task ThenTheUserClicksTheButtonOnThePage()
        {
            await _sampleTestPage.ClickAlertButton();
            await _sampleTestPage.ClickDragAndDropLink();


            // Handle the alert dialog box
            //var dialog = await _page.WaitForEventAsync(PageEvent.Dialog);
            //await dialog.Dialog.AcceptAsync();
        }

    }
}
