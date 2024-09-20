using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class TestBase
    {
        public static IWebDriver driver;
        private string pageUrl = "https://demoqa.com/";

        [TestCleanup]
        public void Cleanup()
        {
            if (driver != null)
                driver.Quit();
        }

        public void StartDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-search-engine-choice-screen");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        public void OpenUrl()
        {
            driver.Navigate().GoToUrl(pageUrl);
        }
    }
}