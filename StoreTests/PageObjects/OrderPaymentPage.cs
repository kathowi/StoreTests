using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace StoreTests.PageObjects
{
    public class OrderPaymentPage : BasePage
    {
        private readonly ElementLocator
            totalPrice = new ElementLocator(Locator.Id, "total_price"),
            payByCheckBtn = new ElementLocator(Locator.ClassName, "cheque"),
            confirmOrderBtn = new ElementLocator(Locator.CssSelector, "p.cart_navigation button"),
            successOrderMessage = new ElementLocator(Locator.ClassName, "alert-success");

        public OrderPaymentPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void CheckTotalPrice(string expectedTotalPrice)
        {
            var actualTotalPrice = Driver.GetElement(totalPrice).Text.Split('$');
            var actualTotalPriceAsNumber = actualTotalPrice[1];

            Assert.AreEqual(expectedTotalPrice, actualTotalPriceAsNumber);
        }

        public void ClickPayByCheck()
        {
            Driver.GetElement(payByCheckBtn).Click();
        }

        public void ClickConfirmMyOrder()
        {
            Driver.GetElement(confirmOrderBtn).Click();
        }

        public void CheckIfSuccessMessageIsVisible(string expectedMessage)
        {
            var actualMessage = Driver.GetElement(successOrderMessage).Text;
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
