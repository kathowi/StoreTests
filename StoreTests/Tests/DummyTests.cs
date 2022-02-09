using NUnit.Framework;
using StoreTests.PageObjects;
using StoreTests;

namespace Dummy.Tests
{
    public class DummyTests : BaseTest
    {

        [Test]
        public void DragAndDropTest()
        {
            var dummy = new DummyPage(DriverContext);

            dummy.OpenDragAndDropPage();
            dummy.DragBoxAAndDropToBoxB();

            dummy.CheckIfBoxAWasSwitchedWithBoxB();
        }

        [Test]
        public void NavigationTest()
        {
            var dummy = new DummyPage(DriverContext);

            dummy.OpenWindowsPage();
            dummy.OpenNewTab();
            dummy.SwitchToNewTab();

            dummy.CheckIfUserIsSwitchedToChosenTab("New Window");
            dummy.TakeAndSaveScreenshot();

            dummy.SwitchToPreviousTab();
            dummy.CheckIfUserIsSwitchedToChosenTab("The Internet");
            dummy.TakeAndSaveScreenshot();
        }

        [Test]
        public void LoadingTestWithExplicitWait()
        {
            var dummy = new DummyPage(DriverContext);

            dummy.OpenDynamicLoadingPage1();
            dummy.ClickStartBtn();

            dummy.CheckIfMessageIsVisible("Hello World!");
        }

        [Test]
        public void LoadingTestWithImplicitWait()
        {
            var dummy = new DummyPage(DriverContext);

            dummy.OpenDynamicLoadingPage2();
            dummy.ClickStartBtn();

            dummy.CheckIfMessageIsVisibleWithTimeout("Hello World!");
        }

    }
}
