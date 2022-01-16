using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace StoreTests.PageObjects
{
    public class ItemPage : BasePage
    {
        private readonly ElementLocator
            addToCartBtn = new ElementLocator(Locator.XPath, "//span[contains(text(),'Add to cart')]"),
            quantityInput = new ElementLocator(Locator.Id, "quantity_wanted"),
            priceInfo = new ElementLocator(Locator.Id, "our_price_display");
        private IWebElement sizeDropdown => Driver.FindElement(By.Id("group_1"));

        public ItemPage(DriverContext driverContext) : base(driverContext)
        {
        }
        public void ClickAddToCart()
        {
            Driver.GetElement(addToCartBtn).Click();
        }

        public void ChangeQuantity(string quantity)
        {
            Driver.GetElement(quantityInput).Clear();
            Driver.GetElement(quantityInput).SendKeys(quantity);
        }
        public void ChangeSize(string size)
        {
            SelectElement select = new SelectElement(sizeDropdown);
            select.SelectByText(size);
        }

        public void ChangeColor(string color)
        {
            Driver.GetElement(new ElementLocator(Locator.CssSelector, $"a[title = '{color}'")).Click();
        }
        public double GetPrice()
        {
            var price = Driver.GetElement(priceInfo).Text.Split('$');
            var priceWithoutCurrency = price[1];
            return ConvertStringToDouble(priceWithoutCurrency);
        }
    }
}

