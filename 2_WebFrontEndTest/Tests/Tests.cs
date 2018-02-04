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
        public void MyTest([Values("bmw")]String searchText,[Values("English")] String language)
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");

            var homePage = new HomePage(driver);
            homePage.SearchFor(searchText, language);
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
