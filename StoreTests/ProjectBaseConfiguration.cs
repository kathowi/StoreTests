using Ocaramba;
using Ocaramba.Helpers;
using System.IO;

namespace StoreTests
{
    public static class ProjectBaseConfiguration
    {
        private static readonly string CurrentDirectory = Directory.GetCurrentDirectory();
        public static string User
        {
            get
            {
                return BaseConfiguration.Builder["appSettings:username"];
            }
        }
        public static string Password
        {
            get
            {
                return BaseConfiguration.Builder["appSettings:password"];
            }
        }

        public static string DataDrivenFile
        {
            get
            {
                if (BaseConfiguration.UseCurrentDirectory)
                {
                    return Path.Combine(CurrentDirectory + BaseConfiguration.Builder["appSettings:DataDrivenFile"]);
                }

                return BaseConfiguration.Builder["appSettings:DataDrivenFile"];
            }
        }
        public static string DataDrivenFileXlsx
        {
            get
            {
                if (BaseConfiguration.UseCurrentDirectory)
                {
                    return Path.Combine(CurrentDirectory + BaseConfiguration.Builder["appSettings:DataDrivenFileXlsx"]);
                }

                return BaseConfiguration.Builder["appSettings:DataDrivenFileXlsx"];
            }
        }
        public static string DownloadFolderPath
        {
            get { return FilesHelper.GetFolder(BaseConfiguration.Builder["appSettings:DownloadFolder"], CurrentDirectory); }
        }
    }
}
