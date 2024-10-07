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
        IList<string> windowHandles = new List<string>(driver.WindowHandles);
        driver.SwitchTo().Window(windowHandles[1]);
    }

    public string GetNewPageText()
    {
        return GetElement(By.Id("sampleHeading"), 5).Text;
    }

    public string GetMessagePageText()
    {
        return GetElement(By.XPath("//body"), 5).Text;
        //return driver.PageSource;
    }

    public void ReturnToMainTab()
    {
        IList<string> windowHandles = new List<string>(driver.WindowHandles);
        driver.SwitchTo().Window(windowHandles[1]);
        driver.Close();

        driver.SwitchTo().Window(windowHandles[0]);
    }

    public void SwitchToNewWindow()
    {
        driver.SwitchTo().Window(driver.WindowHandles.Last());
    }

    public void ReturnToMainPage()
    {
        driver.SwitchTo().Window(driver.WindowHandles.Last());
        driver.Close();
        driver.SwitchTo().Window(driver.WindowHandles.First());
    }

}
