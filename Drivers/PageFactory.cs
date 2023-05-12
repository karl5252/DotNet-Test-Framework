using Microsoft.Playwright;
using System;

namespace SelfServicePortal.Specs.Drivers
{
    public class PageFactory : IPageFactory
    {
        private readonly IBrowser _browser;
        private IPage _page;

        public PageFactory(IBrowser browser)
        {
            _browser = browser;
        }

        public async Task<IPage> NewPageAsync()
        {
            if (_page == null || _page.IsClosed)
            {
                _page = await _browser.NewPageAsync();
            }
            return _page;
        }
    }
}

    
   








