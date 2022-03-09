using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace StoreTests.PageObjects
{
    public class DummyPage : BasePage
    {
        private readonly ElementLocator
            boxA = new ElementLocator(Locator.Id, "column-a"),
            boxB = new ElementLocator(Locator.Id, "column-b"),
            headerBoxA = new ElementLocator(Locator.CssSelector, "#column-a header"),
            headerBoxB = new ElementLocator(Locator.CssSelector, "#column-b header"),
            clickHereLink = new ElementLocator(Locator.LinkText, "Click Here"),
            startBtn = new ElementLocator(Locator.TagName, "button");

        private By finish => By.CssSelector("#finish");

        public DummyPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void OpenDragAndDropPage()
        {
            Driver.NavigateTo(new Uri(Url.DummyDragAndDropUrl));
        }

        public void OpenWindowsPage()
        {
            Driver.NavigateTo(new Uri(Url.DummyWindowsUrl));
        }

        public void OpenDynamicLoadingPage1()
        {
            Driver.NavigateTo(new Uri(Url.DummyDynamicLoadingUrl1));
        }

        public void OpenDynamicLoadingPage2()
        {
            Driver.NavigateTo(new Uri(Url.DummyDynamicLoadingUrl2));
        }

        public void OpenNewTab()
        {
            Driver.GetElement(clickHereLink).Click();
        }

        public void DragBoxAAndDropToBoxB()
        {
            var element = Driver.GetElement(boxA);
            var destination = Driver.GetElement(boxB);

            Driver.DragAndDropJs(element, destination);
        }

        public void SwitchToNewTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        public void SwitchToPreviousTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }

        public void CheckIfUserIsSwitchedToChosenTab(string expectedPageTitle)
        {
            var actualPageTitle = Driver.Title;
            Assert.AreEqual(expectedPageTitle,actualPageTitle);
        }

        public void CheckIfBoxAWasSwitchedWithBoxB()
        {
            var expectedHeaderOfBoxA = "B";
            var expectedHeaderOfBoxB = "A";
            var actualHeaderOfBoxA = Driver.GetElement(headerBoxA).Text;
            var actualHeaderOfBoxB = Driver.GetElement(headerBoxB).Text;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedHeaderOfBoxA, actualHeaderOfBoxA);
                Assert.AreEqual(expectedHeaderOfBoxB, actualHeaderOfBoxB);
            });
        }

        public void ClickStartBtn()
        {
            Driver.GetElement(startBtn).Click();
        }

        public void CheckIfMessageIsVisible(string expectedMessage)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(By.CssSelector("#finish")).Displayed);
            var actualMessage = Driver.FindElement(finish).Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        public void CheckIfMessageIsVisibleWithTimeout(string expectedMessage)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            var actualMessage = Driver.FindElement(finish).Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}