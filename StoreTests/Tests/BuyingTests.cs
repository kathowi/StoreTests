using NUnit.Framework;
using StoreTests.PageObjects;

namespace StoreTests.Tests
{
    public class BuyingTests : BaseTest
    {
        public void AddingItemWithAttributesToCartTest()
        {
            var authentication = new AuthenticationPage(DriverContext);
            var home = new HomePage(DriverContext);
            var category = new CategoryPage(DriverContext);
            var item = new ItemPage(DriverContext);
            var cartPopup = new CartPopupPage(DriverContext);

            string quantity = "4";
            string size = "M";
            string color = "Blue";

            authentication.SignIn();
            home.GoToCategory("Women");
            category.ClickItem("Faded Short Sleeve T-shirts");
            item.ChangeQuantity(quantity);
            item.ChangeSize(size);
            item.ChangeColor(color);
            item.ClickAddToCart();

            cartPopup.CheckIfSuccessMessageIsVisible("Product successfully added to your shopping cart");
            cartPopup.CheckIfSelectedQuantityIsVisible(quantity);
            cartPopup.CheckIfSelectedColorAndSizeAreVisible(color, size);
            cartPopup.CheckIfPriceIsProperlyCalculatedWithGivenQuantity(quantity);

            authentication.ClickSignOut();
        }

        [Test]
        public void BuyingItemTest()
        {
            var authentication = new AuthenticationPage(DriverContext);
            var home = new HomePage(DriverContext);
            var category = new CategoryPage(DriverContext);
            var item = new ItemPage(DriverContext);
            var cartPopup = new CartPopupPage(DriverContext);
            var orderSummary = new OrderSummaryPage(DriverContext);
            var orderAddress = new OrderAddressPage(DriverContext);
            var orderShipping = new OrderShippingPage(DriverContext);
            var orderPayment = new OrderPaymentPage(DriverContext);

            authentication.SignIn();
            home.GoToCategory("Women");
            category.ClickItem("Printed Dress");
            item.ClickAddToCart();
            cartPopup.CheckIfCartIsVisible();
            cartPopup.ClickProceedToCheckout();
            orderSummary.ClickProceedToCheckout();
            orderAddress.ClickProceedToCheckout();
            orderShipping.SelectTermsOfService();
            orderShipping.ClickProceedToCheckout();
            orderPayment.ClickPayByCheck();
            orderPayment.ClickConfirmMyOrder();

            orderPayment.CheckIfSuccessMessageIsVisible("Your order on My Store is complete.");

            authentication.ClickSignOut();
        }
    }
}