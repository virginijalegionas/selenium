using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;




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
        Actions act = new Actions(driver);
        IWebElement element = GetElement(by, 5);
        act.MoveToElement(element).Click().Build().Perform();
    }
    public void ClickOnCheckBox(By by)
    {
        Actions act = new Actions(driver);
        IWebElement element = GetElement(by, 5);
        act.MoveToElement(element).Click().Build().Perform();
    }

    //Format 2004 September 3
    public void SelectDateFromPicker(string year, string month, string day)
    {
        GetElement(By.Id("dateOfBirthInput"), 5).Click();
        SelectElement yearDropDown = new SelectElement(driver.FindElement(By.ClassName("react-datepicker__year-select")));
        yearDropDown.SelectByValue(year);
        SelectElement monthDropDown = new SelectElement(driver.FindElement(By.ClassName("react-datepicker__month-select")));
        //Month Value and text are different need to get Value from the Text
        string monthXpath = $"//option[contains(text(),'{month}')]";
        string monthValue = GetElement(By.XPath(monthXpath), 5).GetAttribute("value");
        monthDropDown.SelectByValue(monthValue);

        string dayXpath = $"//div[@class='react-datepicker__week']//div[text()='{day}' and contains(@aria-label,'{month}')]";
        GetElement(By.XPath(dayXpath), 5).Click();
    }

    public void UploadTestFile(By by, string fileName)
    {
        string fullPath = System.Reflection.Assembly.GetAssembly(typeof(UploadDownload)).Location;
        string theDirectory = Path.GetDirectoryName(fullPath);

        string uploadFile = Path.Combine(theDirectory, $"{fileName}");
        IWebElement fileInput = driver.FindElement(by);
        fileInput.SendKeys(uploadFile);
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
    public bool IsElementDisabled(By by)
    {
        string attribute = GetElement(by, 5).GetAttribute("disabled");
        return attribute == "true";
    }

}