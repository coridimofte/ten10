using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_WebFrontEndTest.UIFramework
{
    public class HomePage
    {
        internal IWebDriver _driver;

        [FindsBy(How=How.Id, Using = "searchInput")]
        public IWebElement SearchInput;

        public SelectElement Language => new SelectElement(_driver.FindElement(By.Id("searchLanguage")));

        [FindsBy(How=How.XPath,Using =".//button[@type='submit']")]
        public IWebElement SearchBtn;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        /// <summary>
        /// Searches for given text and language
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="language"></param>
        public void SearchFor(String searchText, String language="English")
        {
            SearchInput.SendKeys(searchText);
            Language.SelectByText(language);
            SearchBtn.Click();
        }
    }
}
