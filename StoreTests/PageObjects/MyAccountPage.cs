using NLog;
using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using System.Globalization;

namespace StoreTests.PageObjects
{ 
    public class MyAccountPage : BasePage
    {
        private readonly Logger Logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        private readonly ElementLocator
            loggedUser = new ElementLocator(Locator.CssSelector, ".account span"),
            linkSignIn = new ElementLocator(Locator.CssSelector, ".login");

        public MyAccountPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void CheckIfUserIsLogged(string expectedLoggedUser)
        { 
            Logger.Info(CultureInfo.CurrentCulture, "Checking if user is logged in");
            var actualLoggedUser = Driver.GetElement(loggedUser).Text;
            Assert.AreEqual(expectedLoggedUser, actualLoggedUser);
        }

        public void CheckIfUserIsLoggedOut()
        {
            Logger.Info(CultureInfo.CurrentCulture, "Checking if user is logged out");
            Assert.IsTrue(Driver.GetElement(linkSignIn).Displayed);
        }
    }
}