using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class TestBase
    {
        public IWebDriver driver;
        private string pageUrl = "https://demoqa.com/";

        [TestCleanup]
        public void Cleanup()
        {
            driver?.Quit();
        }

        public void StartDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.None;
            options.AddArguments(
                "--disable-search-engine-choice-screen"
                );
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        public void OpenUrl()
        {
            driver.Navigate().GoToUrl(pageUrl);
        }
    }
}