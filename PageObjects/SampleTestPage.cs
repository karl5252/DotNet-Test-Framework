using Microsoft.Playwright;
using SelfServicePortal.Specs.Drivers;
using SelfServicePortal.Specs.Steps;
using TechTalk.SpecFlow;

namespace SelfServicePortal.Specs.PageObjects
{
    public class SampleTestPage : BasePage
    {
        public SampleTestPage(IPageFactory pageFactory) : base(pageFactory)
        {

        }

        public async Task ClickAlertButton()
        {
            var scenarioContext = ScenarioContextHelper.GetScenarioContext();
            var _page = scenarioContext.Get<IPage>("Page");
            //var _page = await GetOrCreatePageAsync(_pageFactory);

            await _page.GetByLabel("Name(required)").ClickAsync();

            await _page.GetByLabel("Name(required)").FillAsync("tester");
        }

        public async Task ClickDragAndDropLink()
        {
            var scenarioContext = ScenarioContextHelper.GetScenarioContext();
            var _page = scenarioContext.Get<IPage>("Page");

            await _page.GetByRole(AriaRole.Link, new() { Name = "Drag And Drop" }).ClickAsync();

        }
    }
}
