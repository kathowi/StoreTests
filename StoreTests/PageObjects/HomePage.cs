using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace StoreTests.PageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(DriverContext driverContext) : base(driverContext)
        {
        }

        private readonly ElementLocator
            logo = new ElementLocator(Locator.XPath, "//a[@title='My Store']"),
            searchField = new ElementLocator(Locator.Id, "search_query_top");

        public void GoToCategory(string categoryName)
        {
            var category = new ElementLocator(Locator.CssSelector, $"a[title='{categoryName}']");
            Driver.GetElement(category).Click();
        }
        public void DragLogoAndDropToSearchField()
        {
            var element = Driver.GetElement(logo);
            var destination = Driver.GetElement(searchField);

            Driver.DragAndDropJs(element, destination);
        }
    }
}
