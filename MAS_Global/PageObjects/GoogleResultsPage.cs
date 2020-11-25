using MAS_Global.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace MAS_Global.PageObjects
{
    public class GoogleResultsLocators : UserActions
    {
        public GoogleResultsLocators(IWebDriver d) : base(d) { }
        public IList<IWebElement> ResultsList() => elements("div[class='g']");

    }

    public class GoogleResultsPage : GoogleResultsLocators
    {
        public GoogleResultsPage(IWebDriver d) : base(d) { }
    }
}
