using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTests;



public class BaseOperations : TestBase
{

    public static void DoubleClickButton(string buttonName)
    {
        //Double click on element

        Actions act = new Actions(driver);
        string xpath = $"//button[contains(text(),'{buttonName}')]";
        IWebElement element = BaseOperations.GetElement(By.XPath(xpath), 5);
        act.DoubleClick(element).Build().Perform();
    }
    public static void Wait(int waitSeconds)
    {
        Thread.Sleep(waitSeconds * 1000);
    }

    public static IWebElement GetElement(By by, int waitSeconds)
    {
        IWebElement element = null;
        if (IsElementExists(by, 5))
        {
            element = driver.FindElement(by);
            ((IJavaScriptExecutor)driver)
        .ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        return element;
    }

    public static List<IWebElement> GetElements(By by, int waitSeconds)
    {
        List<IWebElement> myElements = [];
        if (IsElementExists(by, waitSeconds))
        {
            myElements = driver.FindElements(by).ToList();
            ((IJavaScriptExecutor)driver)
        .ExecuteScript("arguments[0].scrollIntoView();", myElements.Last());
        }
        return myElements;
    }

    public static bool IsElementExists(By by, int waitSeconds)
    {
        for (; waitSeconds > 0; waitSeconds--)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                Wait(1);
            }
        }


        return false;
    }


}