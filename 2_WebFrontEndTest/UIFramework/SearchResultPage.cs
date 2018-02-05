using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_WebFrontEndTest.UIFramework
{
    public class SearchResultPage
    {
        internal IWebDriver _driver;

        [FindsBy(How=How.Id, Using ="firstHeading")]
        public IWebElement FirstHeading;

        [FindsBy(How=How.XPath,Using= ".//*[@id='p-lang']/.//li/a")]
        public IList<IWebElement> AvailableLangs;

        public SearchResultPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        /// <summary>
        /// Returns the first heading text
        /// </summary>
        /// <returns></returns>
        public String GetFirstHeading()
        {
            return FirstHeading.Text;
        }


        /// <summary>
        /// Returs true if given language is available
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public bool LanguageExists(String lang)
        {
            return AvailableLangs.Any(l => l.Text == lang);
        }

        /// <summary>
        /// Navigates to search results page in given language
        /// </summary>
        /// <param name="lang"></param>
        public void NavigateToLanguage(String lang)
        {
            AvailableLangs.Where(l => l.Text == lang).First().Click();
        }


    }
}
