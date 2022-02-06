using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Ocaramba.WebElements;

namespace StoreTests.PageObjects
{
    public class RegistrationPage : BasePage
    {
        private readonly ElementLocator
            //mrRadioBtn = new ElementLocator(Locator.Id, "id_gender1"),
            //mrsRadioBtn = new ElementLocator(Locator.Id, "id_gender2"),
            customerFirstNameInput = new ElementLocator(Locator.Id, "customer_firstname"),
            customerLastNameInput = new ElementLocator(Locator.Id, "customer_lastname"),
            passwordInput = new ElementLocator(Locator.Id, "passwd"),
            //dayDropdown = new ElementLocator(Locator.Id, "days"),
            //monthDropdown = new ElementLocator(Locator.Id, "months"),
            //yearDropdown = new ElementLocator(Locator.Id, "years"),
            //newsletterCheckbox = new ElementLocator(Locator.Id, "newsletter"),
            //specialOffersCheckbox = new ElementLocator(Locator.Id, "optin"),
            companyInput = new ElementLocator(Locator.Id, "company"),
            addressInput = new ElementLocator(Locator.Id, "address1"),
            addressLine2Input = new ElementLocator(Locator.Id, "address2"),
            cityInput = new ElementLocator(Locator.Id, "city"),
            //stateDropdown = new ElementLocator(Locator.Id, "id_state"),
            postalCodeInput = new ElementLocator(Locator.Id, "postcode"),
            additionalInformationTextarea = new ElementLocator(Locator.Id, "other"),
            homePhoneInput = new ElementLocator(Locator.Id, "phone"),
            mobilePhoneInput = new ElementLocator(Locator.Id, "phone_mobile"),
            addressAliasInput = new ElementLocator(Locator.Id, "alias"),
            registerBtn = new ElementLocator(Locator.Id, "submitAccount");

        private IWebElement mrRadioBtn => Driver.FindElement(By.Id("id_gender1"));
        private IWebElement mrsRadioBtn => Driver.FindElement(By.Id("id_gender2"));
        private IWebElement dayDropdown => Driver.FindElement(By.Id("days"));
        private IWebElement monthDropdown => Driver.FindElement(By.Id("months"));
        private IWebElement yearDropdown => Driver.FindElement(By.Id("years"));
        private IWebElement newsletterCheckbox => Driver.FindElement(By.Id("newsletter"));
        private IWebElement specialOffersCheckbox => Driver.FindElement(By.Id("optin"));
        private IWebElement stateDropdown => Driver.FindElement(By.Id("id_state"));

        public RegistrationPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void SelectMrGender()
        { 
            Checkbox checkbox = new Checkbox(mrRadioBtn);
            checkbox.TickCheckbox();
        }
        public void SelectMrsGender()
        {
            Checkbox checkbox = new Checkbox(mrsRadioBtn);
            checkbox.TickCheckbox();
        }
        public void SetCustomerFirstName(string firstName)
        {
            Driver.GetElement(customerFirstNameInput).SendKeys(firstName);
        }
        public void SetCustomerLastName(string lastName)
        {
            Driver.GetElement(customerLastNameInput).SendKeys(lastName);
        }
        public void SetPassword(string password)
        {
            Driver.GetElement(passwordInput).SendKeys(password);
        }
        public void SetDayOfBirth(int day)
        {
            //Select select = Driver.GetElement<Select>(dayDropdown);
            //select.SelectByIndex(day);
            SelectElement select = new SelectElement(dayDropdown);
            select.SelectByIndex(day);
        }
        public void SetMonthOfBirth(int month)
        {
            //Select select = Driver.GetElement<Select>monthDropdown, 2);
            //select.SelectByIndex(month, 2);
            SelectElement select = new SelectElement(monthDropdown);
            select.SelectByIndex(month);
        }
        public void SetYearOfBirth(int year)
        {
            //Select select = Driver.GetElement<Select>yearDropdown, 2);
            //select.SelectByIndex(year, 2);
            SelectElement select = new SelectElement(yearDropdown);
            select.SelectByIndex(year);
        }
        public void SelectNewsletterCheckbox()
        {
            Checkbox checkbox = new Checkbox(newsletterCheckbox);
            checkbox.TickCheckbox();
        }
        public void SelectSpecialOffersCheckbox()
        {
            Checkbox checkbox = new Checkbox(specialOffersCheckbox);
            checkbox.TickCheckbox();
        } 
        public void SetCompany(string company)
        {
            Driver.GetElement(companyInput).SendKeys(company);
        }
        public void SetAddress(string address)
        {
            Driver.GetElement(addressInput).SendKeys(address);
        }
        public void SetAddressLine2(string addressLine2)
        {
            Driver.GetElement(addressLine2Input).SendKeys(addressLine2);
        }
        public void SetCity(string city)
        {
            Driver.GetElement(cityInput).SendKeys(city);
        }
        public void SetState(int state)
        {
            //Select select = Driver.GetElement<Select>stateDropdown, 2);
            //select.SelectByIndex(state, 2);
            SelectElement select = new SelectElement(stateDropdown);
            select.SelectByIndex(state);
        }
        public void SetPostalCode(string postal)
        {
            Driver.GetElement(postalCodeInput).SendKeys(postal);
        }
        public void SetAdditionalInformation(string info)
        {
            Driver.GetElement(additionalInformationTextarea).SendKeys(info);
        }
        public void SetHomePhone(string phone)
        {
            Driver.GetElement(homePhoneInput).SendKeys(phone);
        }
        public void SetMobilePhone(string phone)
        {
            Driver.GetElement(mobilePhoneInput).SendKeys(phone);
        }
        public void SetAddressAlias(string alias)
        {
            Driver.GetElement(addressAliasInput).SendKeys(alias);
        }
        public void ClickRegisterBtn()
        {
            Driver.GetElement(registerBtn).Click();
        } 
        public void FillInAddressInformation(
            string company,
            string address,
            string addressLine2,
            string city,
            int state,
            string postal,
            string info,
            string homePhone,
            string mobilePhone,
            string alias
        )
        {
            SetCompany(company);
            SetAddress(address);
            SetAddressLine2(addressLine2);
            SetCity(city);
            SetState(state);
            SetPostalCode(postal);
            SetAdditionalInformation(info);
            SetHomePhone(homePhone);
            SetMobilePhone(mobilePhone);
            SetAddressAlias(alias);
        }
    }
}
