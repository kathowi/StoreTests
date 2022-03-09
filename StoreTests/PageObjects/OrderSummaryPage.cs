using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace StoreTests.PageObjects
{
    public class OrderSummaryPage : BasePage
    {
        private readonly ElementLocator
            totalPrice = new ElementLocator(Locator.Id, "total_price_container"),
            proceedToCheckoutBtn = new ElementLocator(Locator.CssSelector, ".standard-checkout");

        public OrderSummaryPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void CheckTotalPrice(string expectedTotalPrice)
        {
            var actualTotalPrice = Driver.GetElement(totalPrice).Text.Split('$');
            var actualTotalPriceAsNumber = actualTotalPrice[1];
 
            Assert.AreEqual(expectedTotalPrice, actualTotalPriceAsNumber); 
        }
        public void ClickProceedToCheckout()
        {
            Driver.GetElement(proceedToCheckoutBtn).Click();
        }
    }
}