using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTests;



public class BaseOperations
{
    protected readonly IWebDriver driver;
    public LeftPanel LeftPanel { get; private set; }
    public MainPageMenu MainPageMenu { get; private set; }

    public BaseOperations(IWebDriver driver)
    {
        this.driver = driver;
        LeftPanel = new LeftPanel(this);
        MainPageMenu = new MainPageMenu(this);
    }

    public void GoToHomePage()
    {
        string xpath = "//header/a/img";
        GetElement(By.XPath(xpath), 5).Click();
    }

    public void InputTextField(string xpath, string inputText)
    {
        //string xpath = $"//div/label[contains(text(),'{labelName}')]//parent::div//following-sibling::div/input";
        IWebElement element = GetElement(By.XPath(xpath), 5);
        element.Clear();
        element.SendKeys(inputText);
    }
    public void ClickButton(string xpath)
    {
        GetElement(By.XPath(xpath), 5).Click();
    }
    public void ClickOnRadio(string xpath)
    {
        //string xpath = $"//label[text()='{radioName}']//parent::div/input";
        GetElement(By.XPath(xpath), 5).Click();

    }
    public void RightClickButton(string xpath)
    {
        Actions act = new Actions(driver);
        //string xpath = $"//button[text()='Right Click Me']";
        IWebElement element = GetElement(By.XPath(xpath), 5);
        act.ContextClick(element).Build().Perform();
    }
    public void DoubleClickButton(string xpath)
    {
        Actions act = new Actions(driver);
        //string xpath = $"//button[text()='Double Click Me']";
        IWebElement element = GetElement(By.XPath(xpath), 5);
        act.DoubleClick(element).Build().Perform();
    }

    public IWebElement GetElement(By by, int waitSeconds)
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

    public List<IWebElement> GetElements(By by, int waitSeconds)
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

    public bool IsElementExists(By by, int waitSeconds)
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
                Common.Wait(1);
            }
        }


        return false;
    }


}