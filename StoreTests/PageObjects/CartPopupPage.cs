using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using System;

namespace StoreTests.PageObjects
{
    public class CartPopupPage : BasePage
    {
        private readonly ElementLocator
            cartPopup = new ElementLocator(Locator.CssSelector, ".layer_cart_product"),
            productAddedToCartMessage = new ElementLocator(Locator.CssSelector, ".layer_cart_product h2"),
            quantityInfo = new ElementLocator(Locator.Id, "layer_cart_product_quantity"),
            attributesInfo = new ElementLocator(Locator.Id, "layer_cart_product_attributes"),
            continueShoppingBtn = new ElementLocator(Locator.CssSelector, ".continue"),
            proceedCheckoutBtn = new ElementLocator(Locator.CssSelector, "a[title='Proceed to checkout']");

        public CartPopupPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void CheckIfCartIsVisible()
        {
            Driver.IsElementPresent(cartPopup, 4);
        }

        public void CheckIfSuccessMessageIsVisible(string expectedMessage)
        {
            var actualMessage = Driver.GetElement(productAddedToCartMessage).Text;
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        public void CheckIfSelectedQuantityIsVisible(string expectedQuantity)
        {
            var actualQuantity = Driver.GetElement(quantityInfo).Text;
            Assert.AreEqual(expectedQuantity, actualQuantity);
        }
        public void CheckIfSelectedColorAndSizeAreVisible(string expectedSize, string expectedColor)
        {
            var actualAttributes = Driver.GetElement(attributesInfo).Text;
            Assert.IsTrue(actualAttributes.Contains(expectedSize));
            Assert.IsTrue(actualAttributes.Contains(expectedColor));
        }
        public double CheckIfPriceIsProperlyCalculatedWithGivenQuantity(string quantity)
        {
            var item = new ItemPage(DriverContext);
            var price = item.GetPrice();
            var quantityNumber = Convert.ToInt32(quantity, 16);
            return quantityNumber * price;
        }
        public void ClickContinueShopping()
        {
            Driver.GetElement(continueShoppingBtn).Click();
        }

        public void ClickProceedToCheckout()
        {
            Driver.GetElement(proceedCheckoutBtn).Click();
        }
    }
}
