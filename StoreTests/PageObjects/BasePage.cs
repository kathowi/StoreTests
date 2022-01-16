using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using System;
using System.Globalization;

namespace StoreTests
{
    public partial class BasePage
    {
        public BasePage(DriverContext driverContext)
        {
            DriverContext = driverContext;
            Driver = driverContext.Driver;
        }

        protected IWebDriver Driver { get; set; }

        protected DriverContext DriverContext { get; set; }

        public void OpenHomePage()
        {
            var url = BaseConfiguration.GetUrlValue;
            Driver.NavigateTo(new Uri(url));
        }
        public void OpenSignInPage()
        {
            var signInPage = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
            Driver.NavigateTo(new Uri(signInPage));
        }
        public string GetTimestamp()
        {
            DateTime dt = DateTime.Now;
            string timestamp = dt.ToString("yyyyMMddHHmmss");
            return timestamp;
        }
        public void CheckIfHeaderIsVisible(string header)
        {
            var pageHeader = new ElementLocator(Locator.CssSelector, $".page-heading[text()='{header}']");
            Driver.IsElementPresent(pageHeader, 4);
        }

        public double ConvertStringToDouble(string String)
        {
            CultureInfo usCulture = new CultureInfo("en-US");
            NumberFormatInfo dbNumberFormat = usCulture.NumberFormat;
            return double.Parse(String, dbNumberFormat);
        }
        public void TakeAndSaveScreenshot()
        {
            DriverContext.TakeAndSaveScreenshot();
        }
    }
}
