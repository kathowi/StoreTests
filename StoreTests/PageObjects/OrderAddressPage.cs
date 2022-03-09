using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using System.Collections.Generic;

namespace StoreTests.PageObjects
{
    public class OrderAddressPage : BasePage
    {
        private readonly ElementLocator
            firstAndLastNameDelivery = new ElementLocator(Locator.CssSelector, "#address_delivery .address_firstname"),
            addressDelivery = new ElementLocator(Locator.CssSelector, "#address_delivery .address_address1"),
            cityStatePostcodeDelivery = new ElementLocator(Locator.CssSelector, "#address_delivery .address_city"),
            countryDelivery = new ElementLocator(Locator.CssSelector, "#address_delivery .address_country_name"),
            proceedToCheckoutBtn = new ElementLocator(Locator.Name, "processAddress");
  
        public OrderAddressPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void CheckIfDeliveryAddressIsCorrect(params string[] expectedDeliveryAddress)
        {
            var name = Driver.GetElement(firstAndLastNameDelivery).Text;
            var address = Driver.GetElement(addressDelivery).Text;
            var address2 = Driver.GetElement(cityStatePostcodeDelivery).Text;
            var country = Driver.GetElement(countryDelivery).Text;
            List<string> actualADeliveryAddress = new List<string>{name, address, address2, country};

            Assert.AreEqual(expectedDeliveryAddress, actualADeliveryAddress);
        }
        public void ClickProceedToCheckout()
        {
            Driver.GetElement(proceedToCheckoutBtn).Click();
        }
    }
}