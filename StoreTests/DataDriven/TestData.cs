using System.Collections;

namespace StoreTests.DataDriven{

    public static class TestData
    {
        public static IEnumerable WrongEmail
        {
            get { return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, "wrongEmail", new[] { "wrongEmail", "errorEmailMessage"}, "wrongEmail"); }
        }
        public static IEnumerable WrongPassword
        {
            get { return DataDrivenHelper.ReadDataDriveFile(ProjectBaseConfiguration.DataDrivenFile, "wrongPassword", new[] { "wrongPassword", "errorPasswordMessage" }, "wrongPassword"); }
        }
    }
}
