using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace StoreTests.PageObjects
{
    public class CategoryPage : BasePage
    {
        public CategoryPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void ClickItem(string itemName)
        {
            Driver.GetElement(new ElementLocator(Locator.CssSelector, $".product-name[title='{itemName}'")).Click();
        }
    }
}
