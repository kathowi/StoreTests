using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;

namespace StoreTests.PageObjects
{
    public class AuthenticationPage : BasePage
    {
        private readonly ElementLocator
            linkSignIn = new ElementLocator(Locator.LinkText, "Sign in"),
            emailCreateAccountInput = new ElementLocator(Locator.Id, "email_create"),
            createAnAccountBtn = new ElementLocator(Locator.Id, "SubmitCreate"),
            invalidEmailErrorMessageForRegistration = new ElementLocator(Locator.Id, "create_account_error"),
            emailRegisteredAccountInput = new ElementLocator(Locator.XPath, "//input[@id='email']"),
            passwordInput = new ElementLocator(Locator.CssSelector, "#passwd"),
            invalidErrorMessageForSignIn = new ElementLocator(Locator.CssSelector, "h1 + div.alert"),
            linkSignOut = new ElementLocator(Locator.PartialLinkText, "Sign out");

        public AuthenticationPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void ClickSignIn()
        {
            Driver.GetElement(linkSignIn).Click();
        }
        public void SetEmailToCreateAccount(string email)
        {
            Driver.GetElement(emailCreateAccountInput).SendKeys(email);
        }
        public void ClickCreateAccountBtn()
        {
            Driver.GetElement(createAnAccountBtn).Click();
        }
        public void CheckIfErrorMessageIsVisibleForRegistration(string expectedErrorMessage)
        {
            var actualErrorMessage = Driver.GetElement(invalidEmailErrorMessageForRegistration).Text;
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }
        public void CheckIfErrorMessageIsVisibleForSignIn(string expectedErrorMessage)
        {
            var actualErrorMessage = Driver.GetElement(invalidErrorMessageForSignIn).Text;
            Assert.IsTrue(actualErrorMessage.Contains(expectedErrorMessage));
        }
        public void SetEmailToSignIn(string email)
        {
            Driver.GetElement(emailRegisteredAccountInput).SendKeys(email);
        }
        public void SetPassword(string password)
        {
            Driver.GetElement(passwordInput).SendKeys(password);
        }
        public void ClickSignInBtn()
        { 
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            IWebElement signInBtn = Driver.FindElement(By.Id("SubmitLogin"));
            js.ExecuteScript("arguments[0].click();", signInBtn);
        }
        public void ClickSignOut()
        {
            Driver.GetElement(linkSignOut).Click();
        }
        public void SignIn()
        {
            OpenSignInPage();
            SetEmailToSignIn(ProjectBaseConfiguration.User);
            SetPassword(ProjectBaseConfiguration.Password);
            ClickSignInBtn();
        }
    }
}
