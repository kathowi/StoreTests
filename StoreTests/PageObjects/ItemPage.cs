using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using Ocaramba.WebElements;

namespace StoreTests.PageObjects
{
    public class ItemPage : BasePage
    {
        private readonly ElementLocator
            addToCartBtn = new ElementLocator(Locator.XPath, "//span[contains(text(),'Add to cart')]"),
            quantityInput = new ElementLocator(Locator.Id, "quantity_wanted"),
            sizeDropdown = new ElementLocator(Locator.Id, "group_1"),
            oldPriceInfo = new ElementLocator(Locator.Id, "old_price_display"),
            reductionPercentInfo = new ElementLocator(Locator.Id, "reduction_percent_display"),
            priceInfo = new ElementLocator(Locator.Id, "our_price_display");

        public ItemPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void CheckOldPrice(string expectedOldPrice)
        {
            var oldPrice = Driver.GetElement(oldPriceInfo).Text;
            Assert.AreEqual(expectedOldPrice, oldPrice);
        }

        public void CheckReductionPercent(string expectedReductionPercent)
        {
            var reductionPercent = Driver.GetElement(reductionPercentInfo).Text;
            Assert.AreEqual(expectedReductionPercent, reductionPercent);
        }

        public void CheckNewPrice(string expectedNewPrice)
        {
            var price = Driver.GetElement(priceInfo).Text.Split('$');
            var priceWithoutCurrency = price[1];
            Assert.AreEqual(expectedNewPrice, priceWithoutCurrency);
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
            Select select = Driver.GetElement<Select>(sizeDropdown, e => e.Enabled);
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