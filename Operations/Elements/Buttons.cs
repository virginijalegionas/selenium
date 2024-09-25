using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTests;


public class Buttons : TestBase
{
    public static void ClickClickMeButton()
    {
        Common.ClickButton("Click Me");
    }
    public static void ClickRightClickMeButton()
    {
        Actions act = new Actions(driver);
        string xpath = $"//button[text()='Right Click Me']";
        IWebElement element = BaseOperations.GetElement(By.XPath(xpath), 5);
        act.ContextClick(element).Build().Perform();
    }
    public static void ClickDoubleClickMeButton()
    {
        Actions act = new Actions(driver);
        string xpath = $"//button[text()='Double Click Me']";
        IWebElement element = BaseOperations.GetElement(By.XPath(xpath), 5);
        act.DoubleClick(element).Build().Perform();
    }

    public class Validate
    {
        public static string GetClickMessage()
        {
            string xpath = $"//p[@id='dynamicClickMessage']";
            return BaseOperations.GetElement(By.XPath(xpath), 5).Text;
        }

        public static string GetDoubleClickMessage()
        {
            string xpath = $"//p[@id='doubleClickMessage']";
            return BaseOperations.GetElement(By.XPath(xpath), 5).Text;
        }
        public static string GetRightClickMessage()
        {
            string xpath = $"//p[@id='rightClickMessage']";
            return BaseOperations.GetElement(By.XPath(xpath), 5).Text;
        }

    }

}
