using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace StoreTests.PageObjects
{
    public class OrderShippingPage : BasePage
    {
        private readonly ElementLocator
            termsOfServiceCheckbox = new ElementLocator(Locator.Id, "uniform-cgv"),
            proceedToCheckoutBtn = new ElementLocator(Locator.Name, "processCarrier");

        public OrderShippingPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void SelectTermsOfService()
        {
            Driver.GetElement(termsOfServiceCheckbox).Click();
        }

        public void ClickProceedToCheckout()
        {
            Driver.GetElement(proceedToCheckoutBtn).Click();
        }
    }
}
