using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace StoreTests.PageObjects
{
    public class OrderSummaryPage : BasePage
    {

        private readonly ElementLocator
            proceedToCheckoutBtn = new ElementLocator(Locator.CssSelector, ".standard-checkout");

        public OrderSummaryPage(DriverContext driverContext)
            : base(driverContext)
        {
        }
       public void ClickProceedToCheckout()
        {
            Driver.GetElement(proceedToCheckoutBtn).Click();
        }
    }
}

