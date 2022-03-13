using NUnit.Framework;
using StoreTests.PageObjects;
using StoreTests.DataDriven;
using System.Collections.Generic;

namespace StoreTests.Tests
{
    [TestFixture]
    public class SignInTests : BaseTest
    {
        [SetUp]
        public void BeforeEach()
        {
            var authentication = new AuthenticationPage(DriverContext);
            authentication.OpenSignInPage();
        }

        // test case using data from external file xml
        [Test]
        [TestCaseSource(typeof(TestData), "WrongPassword")]
        public void SignInWithInvalidPassword(IDictionary<string, string> parameters)
        {
            var authentication = new AuthenticationPage(DriverContext);

            string correctEmail = "kaszalotek33@gmail.com";

            authentication.CheckIfHeaderIsVisible("AUTHENTICATION");
            authentication.SetEmailToSignIn(correctEmail);
            authentication.SetPassword(parameters["wrongPassword"]);
            authentication.ClickSignInBtn();

            authentication.CheckIfErrorMessageIsVisibleForSignIn(parameters["errorPasswordMessage"]);
        }

        // test case using data from appsettings
        [Test]
        public void SignInWithValidCredentialsAndSignOut()
        {
            var authentication = new AuthenticationPage(DriverContext);
            var myAccount = new MyAccountPage(DriverContext);

            authentication.CheckIfHeaderIsVisible("AUTHENTICATION");
            authentication.SetEmailToSignIn(ProjectBaseConfiguration.User);
            authentication.SetPassword(ProjectBaseConfiguration.Password);
            authentication.ClickSignInBtn();

            myAccount.CheckIfUserIsLogged("Jan Kowalski");

            authentication.ClickSignOut();

            myAccount.CheckIfUserIsLoggedOut();
        }
    }
}