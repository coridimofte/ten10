using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using _2_WebFrontEndTest.UIFramework;
using System.IO;

namespace _2_WebFrontEndTest.Tests
{
    [TestFixture]
    public class Tests
    {
        internal IWebDriver driver;

        [Test]
        public void MyTest([Values("bmw")]String searchText,[Values("Deutsch")] String language)
        {
            //1. Navigate to the Wikipedia home page, http://www.wikipedia.org/. 
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");

            //2.Search for a given string in English: 
            var homePage = new HomePage(driver);
            homePage.SearchFor(searchText);

            //3.Validate that the first heading of the search results page matches 
            //the search string(ignoring case).
            var searchResultPage = new SearchResultPage(driver);
            var actual = searchResultPage.GetFirstHeading().ToLower().Contains(searchText.ToLower());
            Checkpoint(true, actual, "The first heading does not match the search string.", "The first heading matches the string.");

            //4. Verify that the search results page has link in another language
            //defined as a parameter.
            Checkpoint(true, searchResultPage.LanguageExists(language), "The language is not present", "The language is present");

            //5. Navigate to the search results page in the other language.
            searchResultPage.NavigateToLanguage(language);

            //6.Validate that the search results page in the other language includes 
            //a link to the version in English.
            Checkpoint(true, searchResultPage.LanguageExists("English"), "The language is not present", "The language is present");
        }

        /// <summary>
        /// Checkpoint method
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="current"></param>
        /// <param name="errMsg"></param>
        /// <param name="successMsg"></param>
        public void Checkpoint(bool expected, bool current, String errMsg, String successMsg)
        {
            Assert.AreEqual(expected, current, errMsg);
            Console.Out.WriteLine("----Checkpoint passed---- :" + successMsg); ;
        }
        /// <summary>
        /// Test case setup; it is run for each test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Console.Out.WriteLine($"-----------{TestContext.CurrentContext.Test.Properties["Description"]}-----------");

            driver = GetDriver();
            driver.Manage().Window.Maximize();
            //_driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            //_driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));

        }

        /// <summary>
        /// Test case "clean up"; it is run after each test
        /// </summary>
        [TearDown]
        public void Close()
        {
           driver.Quit();
        }

        /// <summary>
        /// Returns an instance of Chrome driver
        /// </summary>
        /// <returns></returns>
        public IWebDriver GetDriver()
        {
            var opts = new ChromeOptions();
            opts.AddArgument("test-type");
            return new ChromeDriver(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), opts);
        }
    }
}
