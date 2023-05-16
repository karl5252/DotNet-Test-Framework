using Microsoft.Playwright;
using SelfServicePortal.Specs.Drivers;

namespace SelfServicePortal.Specs.PageObjects
{
    public class SampleTestPageDragDrop : BasePage
    {
        public SampleTestPageDragDrop(IPageFactory pageFactory) : base(pageFactory)
        {

        }

        public async Task ClickTabsAsync()
        {
            var _page = await GetOrCreatePageAsync(_pageFactory);
            await _page.FrameLocator("iframe[name=\"aswift_4\"]").FrameLocator("iframe[name=\"ad_iframe\"]").GetByRole(AriaRole.Button, new() { Name = "Close ad" }).ClickAsync();
            await _page.GetByRole(AriaRole.Tab, new() { Name = "Accepted Elements" }).ClickAsync();
            await _page.GetByRole(AriaRole.Tab, new() { Name = "Propagation" }).ClickAsync();
        }
    }
}
