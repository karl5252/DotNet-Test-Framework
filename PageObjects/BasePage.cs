using Microsoft.Playwright;
using SelfServicePortal.Specs.Drivers;
using static System.Net.Mime.MediaTypeNames;

namespace SelfServicePortal.Specs.PageObjects
{
    public class BasePage
    {
        protected readonly IPageFactory _pageFactory;
        protected IPage _page;

        public BasePage(IPageFactory pageFactory)
        {
            _pageFactory = pageFactory;
            //_page = page;
        }
        protected async Task<IPage> GetOrCreatePageAsync(IPageFactory pageFactory)
        {
            if (_page == null || _page.IsClosed)
            {
                _page = await pageFactory.NewPageAsync();
            }

            return _page;
        }
        public async Task CreatePageAsync(string url)
        {
            _page = await _pageFactory.NewPageAsync();
            await _page.GotoAsync(url);
            await _page.WaitForLoadStateAsync();
        }

    }
}