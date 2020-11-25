using MAS_Global.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace MAS_Global.PageObjects
{
    public class GoogleIniLocators : UserActions
    {
        public GoogleIniLocators(IWebDriver d) : base(d) { }
        public IWebElement SearchBar() => element("input[class='gLFyf gsfi']");
        public IWebElement GoogleSearchButton() => element("input[class='gNO89b']");
        public IList<IWebElement> SuggestionList() => elements(".erkvQe li");
    }

    public class GoogleIniPage : GoogleIniLocators
    {
        public GoogleIniPage(IWebDriver d) : base(d) { }

        public void SearchText(string description)
        {
            write(description, SearchBar);
            sleep();
            click(GoogleSearchButton());
        }

        public void SearchSuggestion(string description)
        {
            write(description, SearchBar);
            sleep();
            click(SuggestionList()[0]);
        }

    }
}
