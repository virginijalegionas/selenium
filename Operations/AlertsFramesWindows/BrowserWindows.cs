using OpenQA.Selenium;

public class BrowserWindows : BaseOperations
{
    public BrowserWindows(IWebDriver driver) : base(driver)
    {
    }

    public void ClickNewTabButton()
    {
        ClickButton(By.Id("tabButton"));
    }

    public void ClickNewWindowButton()
    {
        ClickButton(By.Id("windowButton"));
    }

    public void ClickNewWindowMessageButton()
    {
        ClickButton(By.Id("messageWindowButton"));
    }

    public void SwitchToNewTab()
    {
        driver.SwitchTo().Window(driver.WindowHandles[1]);
    }

    public string GetNewPageText()
    {
        return GetElement(By.Id("sampleHeading"), 5).Text;
    }

    public string GetMessagePageText()
    {
        return GetElement(By.XPath("//body"), 5).Text;
    }

    public void ReturnToMainTab()
    {
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        driver.Close();
        driver.SwitchTo().Window(driver.WindowHandles[0]);
    }

    public void SwitchToNewWindow()
    {
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        driver.Manage().Window.Maximize();
    }

    public void ReturnToMainPage()
    {
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        driver.Close();
        driver.SwitchTo().Window(driver.WindowHandles[0]);
    }
}
