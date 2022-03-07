using NUnit.Framework;
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
            oldPriceInfo = new ElementLocator(Locator.Id, "old_price_display"),
            reductionPercentInfo = new ElementLocator(Locator.Id, "reduction_percent_display"),
            priceInfo = new ElementLocator(Locator.Id, "our_price_display"),
            colorSelector = new ElementLocator(Locator.CssSelector, "a[title='{0}'");

        private IWebElement sizeDropdown => Driver.FindElement(By.Id("group_1"));

        public ItemPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public ItemPage CheckOldPrice(string expectedOldPrice)
        {
            var oldPrice = Driver.GetElement(oldPriceInfo).Text;
            Assert.AreEqual(expectedOldPrice, oldPrice);
            return this;
        }

        public ItemPage CheckReductionPercent(string expectedReductionPercent)
        {
            var reductionPercent = Driver.GetElement(reductionPercentInfo).Text;
            Assert.AreEqual(expectedReductionPercent, reductionPercent);
            return this;
        }

        public void CheckNewPrice(string expectedNewPrice)
        {
            var price = Driver.GetElement(priceInfo).Text.Split('$');
            var priceWithoutCurrency = price[1];
            Assert.AreEqual(expectedNewPrice, priceWithoutCurrency);
        }

        public CartPopupPage ClickAddToCart()
        {
            Driver.GetElement(addToCartBtn).Click();
            return new CartPopupPage(DriverContext);
        }

        public ItemPage ChangeQuantity(string quantity)
        {
            Driver.GetElement(quantityInput).Clear();
            Driver.GetElement(quantityInput).SendKeys(quantity);
            return this;
        }

        public ItemPage ChangeSize(string size)
        {
            SelectElement select = new SelectElement(sizeDropdown);
            select.SelectByText(size);
            return this;
        }

        public ItemPage ChangeColor(string color)
        {
            Driver.GetElement(colorSelector.Format(color)).Click();
            return this;
        }

        public double GetPrice()
        {
            var price = Driver.GetElement(priceInfo).Text.Split('$');
            var priceWithoutCurrency = price[1];
            return ConvertStringToDouble(priceWithoutCurrency);
        }
    }
}
