using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace StoreTests.PageObjects
{
    public class OrderPaymentPage : BasePage
    {
        private readonly ElementLocator
            payByCheckBtn = new ElementLocator(Locator.ClassName, "cheque"),
            confirmOrderBtn = new ElementLocator(Locator.CssSelector, "p.cart_navigation button"),
            successOrderMessage = new ElementLocator(Locator.ClassName, "alert-success");

        public OrderPaymentPage(DriverContext driverContext) : base(driverContext)
        {
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
