using Microsoft.Playwright;
using SelfServicePortal.Specs.Drivers;
using SelfServicePortal.Specs.Steps;
using TechTalk.SpecFlow;

namespace SelfServicePortal.Specs.PageObjects
{
    public class GooglePage : BasePage
    {
        public GooglePage(IPageFactory pageFactory) : base(pageFactory)
        {

            //_page = pageFactory.NewPageAsync();
        }
        /*public async Task<IPage> OpenAsync(string url)
        {
            var page = await _pageFactory.NewPageAsync();
            _page = page;
            await _page.GotoAsync(url);
            await _page.WaitForLoadStateAsync();

            return page;
        }*/
        //public async Task OpenAsync(string)
        public async Task TypeInSearchBar(string text) 
        {
            var _page = await GetOrCreatePageAsync(_pageFactory);
            await _page.FillAsync("textarea", text);
        }
        public async Task ClickSearch() 
        {
            var scenarioContext = ScenarioContextHelper.GetScenarioContext();
            scenarioContext.Set(_page, "Page");
            await _page.GetByRole(AriaRole.Button, new() { Name = "Odrzuć wszystko" }).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Szukaj w Google" }).ClickAsync();

            //await _page.WaitForNavigationAsync();

            // Click on the first search result link
            await _page.GetByRole(AriaRole.Link, new() { Name = "Sample Page Testing Site Online - Global SQA Testing Sites globalsqa.com https://www.globalsqa.com › samp..." }).ClickAsync();

        }
    }
}
