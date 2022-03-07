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
            categories = new ElementLocator(Locator.ClassName, "cat-title"),
            category = new ElementLocator(Locator.CssSelector, "a[title='{0}']");

        public HomePage ClickCategories()
        {
            Driver.GetElement(categories).Click();
            return this;
        }

        public CategoryPage GoToCategory(string categoryName)
        {
            Driver.GetElement(category.Format(categoryName)).Click();
            return new CategoryPage(DriverContext);
        }
    }
}
