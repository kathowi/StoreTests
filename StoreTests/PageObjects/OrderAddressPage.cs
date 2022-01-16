using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace StoreTests.PageObjects
{
    public class OrderAddressPage : BasePage
    {
        private readonly ElementLocator
            proceedToCheckoutBtn = new ElementLocator(Locator.Name, "processAddress");
  
        public OrderAddressPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void ClickProceedToCheckout()
        {
            Driver.GetElement(proceedToCheckoutBtn).Click();
        }
    }
}

