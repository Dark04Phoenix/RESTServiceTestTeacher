using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
namespace RESTServiceTestTeacher

{
    [TestClass]
    public class UnitTest1
    {

        private static readonly string DriverDirectory = "C:\\webDrivers";
        private static IWebDriver _driver;

        // https://www.automatetheplanet.com/mstest-cheat-sheet/
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //_driver = new ChromeDriver(DriverDirectory); // fast
            // if your Chrome browser was updated, you must update the driver as well ...
            //    https://chromedriver.chromium.org/downloads
            //_driver = new FirefoxDriver(DriverDirectory);  // slow
            _driver = new ChromeDriver(DriverDirectory); //  fast
            // Driver file must be renamed to MicrosoftWebDriver.exe OR msedgedriver.exe
            // depending on the version of Selenium?
        }

        [TestMethod]
        public void TestMethod1()
        {
            string url = "C:\\Users\\AMejd\\OneDrive\\سطح المكتب\\Zealand\\HTML\\RestServiceJavaScriptOpg\\Teachers.html";
            _driver.Navigate().GoToUrl(url);

            string title = _driver.Title;
            Assert.AreEqual("Teachers Controller", title);

            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();

  

            //pause(60); // NOT good, will always wait full 60 sec

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement teacherlist = wait.Until(d => d.FindElement(By.Id("teacherlist")));
            Assert.IsTrue(teacherlist.Text.Contains("Jonas"));

            // We already did the waiting in the previous lines, so now we can go back to using the ordinary driver
            ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.TagName("li"));
            Assert.AreEqual(3, listElements.Count);

            Assert.IsTrue(listElements[0].Text.Contains("Jonas"));

            // XPath, an advanced option to use By.XPath(...)
            // https://www.guru99.com/handling-dynamic-selenium-webdriver.html
        }
    }
}