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
        private readonly ElementLocator
            pageHeader = new ElementLocator(Locator.CssSelector, ".page-heading[text()='{0}']");

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
            Driver.NavigateTo(new Uri(Url.SignIn));
        }

        public string GetTimestamp()
        {
            return $"{DateTime.Now:yyyyMMddHHmmss}";
        }

        public void CheckIfHeaderIsVisible(string header)
        {
            Driver.IsElementPresent(pageHeader.Format(header), 4);
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
