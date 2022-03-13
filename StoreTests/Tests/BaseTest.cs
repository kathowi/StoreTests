using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Ocaramba;
using Ocaramba.Logger;

namespace StoreTests
{
    public class BaseTest : TestBase
    {
        private readonly DriverContext driverContext = new DriverContext();

        public TestLogger LogTest
        {
            get
            {
                return DriverContext.LogTest;
            }

            set
            {
                DriverContext.LogTest = value;
            }
        }

        protected DriverContext DriverContext
        {
            get
            {
                return driverContext;
            }
        }

        [OneTimeSetUp]
        public void BeforeClass()
        {
            DriverContext.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
            DriverContext.Start();
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            DriverContext.Stop();
        }
 
        [SetUp]
        public void BeforeTest()
        {
            DriverContext.TestTitle = TestContext.CurrentContext.Test.Name;
            LogTest.LogTestStarting(driverContext);
        }
 
        [TearDown]
        public void AfterTest()
        {
            DriverContext.IsTestFailed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed || !driverContext.VerifyMessages.Count.Equals(0);
            var filePaths = SaveTestDetailsIfTestFailed(driverContext);
            SaveAttachmentsToTestContext(filePaths);
            LogTest.LogTestEnding(driverContext);
            var javaScriptErrors = DriverContext.LogJavaScriptErrors();
            if (IsVerifyFailedAndClearMessages(driverContext) && TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed)
            {
                Assert.Fail();
            }

            if (javaScriptErrors)
            {
                Assert.Fail("JavaScript errors found. See the logs for details");
            }
        }

        private void SaveAttachmentsToTestContext(string[] filePaths)
        {
            if (filePaths != null)
            {
                foreach (var filePath in filePaths)
                {
                    LogTest.Info("Uploading file [{0}] to test context", filePath);
                    TestContext.AddTestAttachment(filePath);
                }
            }
        }
    }
}