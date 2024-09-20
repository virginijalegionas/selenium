using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests;
using System;



//[TestClass]
public class Common
{


}

public class BaseOperations : TestBase
{

    public static IWebDriver driver = TestBase.driver;

    public static void wait(double waitSeconds)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitSeconds);
    }

    public static void click(string xpath, int waitSeconds)
    {
        IWebElement element = null;

        while (element == null && waitSeconds != 0)
        {
            element = driver.FindElement(By.XPath(xpath));
            if (element != null)
            {
                element.Click();
            }
        }
        
    }


}