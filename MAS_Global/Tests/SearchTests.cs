using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using MAS_Global.Common;
using MAS_Global.PageObjects;

namespace TestAutomation.Tests {
    public class SearchTests : UserActions {
        GoogleIniPage onGoogleIniPage;
        GoogleResultsPage onGoogleResultsPage;

        [OneTimeSetUp]
        public new void Setup() 
        {
            Image.deleteAll();
            Init();
            onGoogleIniPage = new GoogleIniPage(driver);
            onGoogleResultsPage = new GoogleResultsPage(driver);
        }

        [Test]
        [Description("Test Case 1: User can search with 'Google Search'")]
        public void _TestCase1()
        {
            onGoogleIniPage.SearchText("The name of the wind");
            var resultList = onGoogleResultsPage.ResultsList();
            var link = resultList[0].FindElement(By.TagName("a"));
            var title= resultList[0].FindElement(By.TagName("span")).Text;
            Assert.AreEqual("The Name of the Wind - Patrick Rothfuss", title);
            click(link);
            
        }

        [Test]
        [Description("Test Case 2: User can search by using the suggestions")]
        public void _TestCase2()
        {
            onGoogleIniPage.SearchSuggestion("The name of the w");
            var resultList = onGoogleResultsPage.ResultsList();
            var link = resultList[0].FindElement(By.TagName("a"));
            var title = resultList[0].FindElement(By.TagName("span")).Text;
            Assert.AreEqual("The Name of the Wind - Patrick Rothfuss", title);
            click(link);

        }

        [OneTimeTearDown]
        public void TearDown() {
            driver.Quit();
        }
    }
}