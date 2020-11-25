using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Linq;

namespace MAS_Global.Common
{
    public class Image
    {
        IWebDriver driver;

        public Image(IWebDriver d)
        {
            driver = d;
            deleteAll();
        }

        /// <summary>
        /// Takes a screenshot of the page, by default it will name it with the Test Case name.
        /// </summary>
        public void take(string imageName = "")
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomString = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray()).ToLower();
            var fullContext = TestContext.CurrentContext.Test.FullName;
            var testName = fullContext.Contains("(") ? fullContext.Substring(0, fullContext.IndexOf("(")) : fullContext;
            imageName = imageName == "" ? "" : " - " + imageName;
            var fileName = testName + " " + DateTime.Now.ToUniversalTime().ToString().Replace(":", ".").Replace("/", "-") + " " + randomString + " " + imageName;
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = dir.Substring(0, dir.LastIndexOf("MAS_Global")) + "Screenshots\\";
            var imagePath = path + fileName + ".png";
            try
            {
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(imagePath, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(imagePath);
            }
            catch (System.Exception) { }
        }

        /// <summary>
        /// Deletes all screenshots for the given namespace
        /// </summary>
        public static void deleteAll()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var screenshots_path = dir.Substring(0, dir.LastIndexOf("MAS_Global")) + "Screenshots\\";
            var notInATest = TestContext.CurrentContext.Test.MethodName == null ? true : false;
            if (notInATest)
            {
                foreach (FileInfo file in new DirectoryInfo(screenshots_path).GetFiles())
                {
                    if (file.Name.Contains(TestContext.CurrentContext.Test.FullName))
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch (System.Exception) { }
                    }
                }
            }
        }
    }
}
