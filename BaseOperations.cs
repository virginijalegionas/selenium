using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;



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

    public void InputTextField(By by, string inputText)
    {
        IWebElement element = GetElement(by, 5);
        element.Clear();
        element.SendKeys(inputText);
    }
    public void ClickButton(By by)
    {
        GetElement(by, 5).Click();
    }
    public void ClickOnRadio(By by)
    {
        GetElement(by, 5).Click();

    }
    public void RightClickButton(By by)
    {
        Actions act = new Actions(driver);
        IWebElement element = GetElement(by, 5);
        act.ContextClick(element).Build().Perform();
    }
    public void DoubleClickButton(By by)
    {
        Actions act = new Actions(driver);
        IWebElement element = GetElement(by, 5);
        act.DoubleClick(element).Build().Perform();
    }

    public IWebElement GetElement(By by, int waitSeconds)
    {
        IWebElement element = null;
        if (IsElementExists(by, waitSeconds))
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