using System.IO;


namespace SeleniumTest.Utils
{
    internal class Utility
    {
        public static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }
    }
}
