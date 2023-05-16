using Microsoft.Playwright;
using SelfServicePortal.Specs.Drivers;

namespace SelfServicePortal.Specs.PageObjects
{
    public class SampleTestPage : BasePage
    {
        public SampleTestPage(IPageFactory pageFactory) : base(pageFactory)
        {
           // _page = pageFactory.NewPageAsync()
        }

        public async Task ClickAlertButton()
        {
            var _page = await GetOrCreatePageAsync(_pageFactory);

            await _page.GetByLabel("Name(required)").ClickAsync();

            await _page.GetByLabel("Name(required)").FillAsync("tester");
        }

        public async Task ClickDragAndDropLink()
        {
            await _page.GetByRole(AriaRole.Link, new() { Name = "Drag And Drop" }).ClickAsync();

        }
    }
}
