using NUnit.Framework;
using StoreTests.PageObjects;

namespace StoreTests.Tests
{
    [TestFixture]
    public class BuyingTests : BaseTest
    {
        [SetUp]
        public void BeforeEach()
        {
            var authentication = new AuthenticationPage(DriverContext);
            authentication.SignIn();
        }

        [Test]
        public void AddingItemWithAttributesToCartTest()
        {
            var home = new HomePage(DriverContext);
            var category = new CategoryPage(DriverContext);
            var item = new ItemPage(DriverContext);
            var cartPopup = new CartPopupPage(DriverContext);
            var authentication = new AuthenticationPage(DriverContext);

            string categoryName = "Women";
            string itemName = "Faded Short Sleeve T-shirts";
            string quantity = "4";
            string size = "M";
            string color = "Blue";

            home.ClickCategories();
            home.GoToCategory(categoryName);
            category.ClickItem(itemName);
            item.ChangeQuantity(quantity);
            item.ChangeSize(size);
            item.ChangeColor(color);
            item.ClickAddToCart();

            cartPopup.CheckIfSuccessMessageIsVisible("Product successfully added to your shopping cart");
            cartPopup.CheckIfSelectedQuantityIsVisible(quantity);
            cartPopup.CheckIfSelectedColorAndSizeAreVisible(color, size);
            cartPopup.CheckIfPriceIsProperlyCalculatedWithGivenQuantity(quantity);

            authentication.LogOut();
        }

        [Test]
        public void BuyingItemTest()
        {
            var home = new HomePage(DriverContext);
            var category = new CategoryPage(DriverContext);
            var item = new ItemPage(DriverContext);
            var cartPopup = new CartPopupPage(DriverContext);
            var orderSummary = new OrderSummaryPage(DriverContext);
            var orderAddress = new OrderAddressPage(DriverContext);
            var orderShipping = new OrderShippingPage(DriverContext);
            var orderPayment = new OrderPaymentPage(DriverContext);
            var authentication = new AuthenticationPage(DriverContext);

            string categoryName = "Women";
            string itemName = "Printed Dress";
            string name = "Jan Kowalski";
            string totalPrice = "28.00";
            string address = "Onion";
            string address2 = "Los Angeles, California 00000";
            string country = "United States";

            home.ClickCategories();
            home.GoToCategory(categoryName);
            category.ClickItem(itemName);
            item.ClickAddToCart();
            cartPopup.CheckIfCartIsVisible();
            cartPopup.ClickProceedToCheckout();
            orderSummary.CheckTotalPrice(totalPrice);
            orderSummary.ClickProceedToCheckout();
            orderAddress.CheckIfDeliveryAddressIsCorrect(name, address, address2, country);
            orderAddress.ClickProceedToCheckout();
            orderShipping.SelectTermsOfService();
            orderShipping.ClickProceedToCheckout();
            orderPayment.CheckTotalPrice(totalPrice);
            orderPayment.ClickPayByCheck();
            orderPayment.ClickConfirmMyOrder();

            orderPayment.CheckIfSuccessMessageIsVisible("Your order on My Store is complete.");

            authentication.LogOut();
        }

        [Test]
        public void BuyingItemWithDiscountTest()
        {
            var home = new HomePage(DriverContext);
            var category = new CategoryPage(DriverContext);
            var item = new ItemPage(DriverContext);
            var cartPopup = new CartPopupPage(DriverContext);
            var orderSummary = new OrderSummaryPage(DriverContext);
            var orderAddress = new OrderAddressPage(DriverContext);
            var orderShipping = new OrderShippingPage(DriverContext);
            var orderPayment = new OrderPaymentPage(DriverContext);
            var authentication = new AuthenticationPage(DriverContext);

            string categoryName = "Women";
            string itemName = "Printed Summer Dress";
            string reductionPercent = "-5%";
            string oldPrice = "$30.51";
            string newPrice = "28.98";
            string totalPrice = "30.98";

            home.ClickCategories();
            home.GoToCategory(categoryName);
            category.ClickItem(itemName);
            item.CheckOldPrice(oldPrice);
            item.CheckReductionPercent(reductionPercent);
            item.CheckNewPrice(newPrice);
            item.ClickAddToCart();
            cartPopup.CheckIfCartIsVisible();
            cartPopup.ClickProceedToCheckout();
            orderSummary.CheckTotalPrice(totalPrice);
            orderSummary.ClickProceedToCheckout();
            orderAddress.ClickProceedToCheckout();
            orderShipping.SelectTermsOfService();
            orderShipping.ClickProceedToCheckout();
            orderPayment.CheckTotalPrice(totalPrice);
            orderPayment.ClickPayByCheck();
            orderPayment.ClickConfirmMyOrder();

            orderPayment.CheckIfSuccessMessageIsVisible("Your order on My Store is complete.");

            authentication.LogOut();
        }
    }
}