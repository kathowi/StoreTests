using NUnit.Framework;
using StoreTests.PageObjects;
using StoreTests.DataDriven;
using System.Collections.Generic;

namespace StoreTests
{
    [TestFixture]
    public class RegistrationAccountTests : BaseTest
    {
        // test case using data from external file xml
        [Test]
        [TestCaseSource(typeof(TestData), "WrongEmail")]
        public void RegisterAccountWithInvalidEmailTest(IDictionary<string, string> parameters)
        {
            var authentication = new AuthenticationPage(DriverContext);

            authentication.OpenHomePage();
            authentication.ClickSignIn();
            authentication.CheckIfHeaderIsVisible("AUTHENTICATION");
            authentication.SetEmailToCreateAccount(parameters["wrongEmail"]);
            authentication.ClickCreateAccountBtn();

            authentication.CheckIfErrorMessageIsVisibleForRegistration(parameters["errorEmailMessage"]);
        }

        // test case using data inside
        [Test]
        public void RegisterAccountWithAlreadyRegisteredEmailTest()
        {
            var authentication = new AuthenticationPage(DriverContext);

            string alreadyRegisteredEmail = "kaszalotek33@gmail.com";

            authentication.OpenSignInPage();
            authentication.CheckIfHeaderIsVisible("AUTHENTICATION");
            authentication.SetEmailToCreateAccount(alreadyRegisteredEmail);
            authentication.ClickCreateAccountBtn();

            authentication.CheckIfErrorMessageIsVisibleForRegistration("An account using this email address has already been registered. Please enter a valid password or request a new one.");
        }

        // test case using method with the parameters FillInAddressInformation
        [Test]
        public void RegisterAccountWithValidEmailTest()
        {
            var authentication = new AuthenticationPage(DriverContext);
            var registration = new RegistrationPage(DriverContext);
            var myaccount = new MyAccountPage(DriverContext);

            string timestamp = authentication.GetTimestamp();
            string email = $"kaszalotek33+{timestamp}@gmail.com";
            string firstName = "Jan";
            string lastName = "Kowalski";
            string password = "Secretpass";
            int index = 3;
            string company = "TestFest";
            string address = "Aleja Krakowska";
            string addressLine2 = "2/4";
            string city = "Wrocław";
            int state = 3;
            string postal = "00000";
            string info = "Test Info";
            string homePhone = "44567";
            string mobilePhone = "48123456789";
            string alias = "XYZ";

            authentication.OpenSignInPage();
            authentication.SetEmailToCreateAccount(email);
            authentication.ClickCreateAccountBtn();
            registration.CheckIfHeaderIsVisible("CREATE AN ACCOUNT");
            registration.SelectMrGender();
            registration.SetCustomerFirstName(firstName);
            registration.SetCustomerLastName(lastName);
            registration.SetPassword(password);
            registration.SetDayOfBirth(index);
            registration.SetMonthOfBirth(index);
            registration.SetYearOfBirth(index);
            registration.SelectNewsletterCheckbox();
            registration.SelectSpecialOffersCheckbox();
            registration.FillInAddressInformation(company, address, addressLine2, city, state, postal, info, homePhone, mobilePhone, alias);
            registration.ClickRegisterBtn();

            myaccount.CheckIfUserIsLogged($"{firstName} {lastName}");
        }
    }
}
