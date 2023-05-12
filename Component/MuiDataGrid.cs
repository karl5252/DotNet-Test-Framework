using Microsoft.Playwright;

namespace SelfServicePortal.Specs.Component
{
    /// <summary>
    /// Class to hold MuiGrid table related methods.
    /// </summary>
    public class MuiDataGrid
    {
        private readonly IPage _page;
        private readonly string _gridSelector;

        public MuiDataGrid(IPage page, string gridSelector) //var elementHandle = await page.QuerySelectorAsync("div[class*='MuiDataGrid-virtualScrollerRenderZone']");

        {
            _page = page;
            _gridSelector = gridSelector;
        }

        public async Task<int> GetRowCountAsync()
        {
            var selector = $"{_gridSelector}.MuiDataGrid-row";
            await _page.WaitForSelectorAsync(selector);
            IEnumerable<IElementHandle> rows = await _page.QuerySelectorAllAsync(selector);
            if (rows == null)
            {
                return 0;
            }
            return rows.Count();
        }
        public async Task<IElementHandle> GetCellAsync(int rowIndex, int columnIndex)
        {
            var selector = $"{_gridSelector} [data-rowindex='{rowIndex}'] [data-colindex='{columnIndex}']";
            await _page.WaitForSelectorAsync(selector);
            return await _page.QuerySelectorAsync(selector);
        }
        public async Task<IReadOnlyList<IReadOnlyList<string>>> GetRowValuesAsync()
        {
            var selector = $"{_gridSelector} .MuiDataGrid-row";
            await _page.WaitForSelectorAsync(selector);
            var rows = await _page.QuerySelectorAllAsync(selector);
            var rowValues = new List<IReadOnlyList<string>>();
            foreach (var row in rows)
            {
                var cells = await row.QuerySelectorAllAsync(".MuiDataGrid-cell");
                var cellValues = new List<string>();
                foreach (var cell in cells)
                {
                    var cellValue = await cell.InnerTextAsync();
                    cellValues.Add(cellValue);
                }
                rowValues.Add(cellValues);
            }
            return rowValues;
        }


        public async Task<IReadOnlyList<IReadOnlyList<string>>> GetCellValuesAsync()
        {
            var selector = $"{_gridSelector}.MuiDataGrid-row";
            await _page.WaitForSelectorAsync(selector);
            var cells = await _page.QuerySelectorAllAsync(selector);
            var rows = cells.GroupBy(async c => await c.GetAttributeAsync("data-rowindex"))
                            .OrderBy(async g => int.TryParse(await g.Key, out int index) ? index : int.MaxValue)
                            .Select(g => g.Select(async c => await c.InnerTextAsync()));

            return rows.Select(r => (IReadOnlyList<string>)r.ToList()).ToList();
        }
    }


}
