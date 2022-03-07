using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace StoreTests.PageObjects
{
    public class CategoryPage : BasePage
    {
        private readonly ElementLocator
            itemLocator = new ElementLocator(Locator.CssSelector, ".product-name[title='{0}'");

        public CategoryPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public ItemPage ClickItem(string itemName)
        {
            Driver.GetElement(itemLocator.Format(itemName)).Click();
            return new ItemPage(DriverContext);
        }
    }
}
