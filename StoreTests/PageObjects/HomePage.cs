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
            categories = new ElementLocator(Locator.ClassName, "cat-title");

        public void ClickCategories()
        {
            Driver.GetElement(categories).Click();
        }

        public void GoToCategory(string categoryName)
        {
            var category = new ElementLocator(Locator.CssSelector, $"a[title='{categoryName}']");
            Driver.GetElement(category).Click();
        }
    }
}