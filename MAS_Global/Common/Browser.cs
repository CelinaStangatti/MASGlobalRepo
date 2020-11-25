using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MAS_Global.Common {
    class Browser {
        public static IWebDriver Chrome {
            get {
                var headless = TestContext.Parameters.Get("headless") != "" && TestContext.Parameters.Get("headless") != null ? true : false;
                ChromeOptions options = new ChromeOptions();
                if (headless) {
                    options.AddArgument("--headless");
                    options.AddArgument("--window-size=1920,1080");
                }
                options.AddArgument("--start-maximized");
                return new ChromeDriver(options);
            }
        }
    }
}