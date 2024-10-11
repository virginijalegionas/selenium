using OpenQA.Selenium;

public class Tabs : BaseOperations
{
    public Tabs(IWebDriver driver) : base(driver)
    {
    }

    public void ClickOnTab(string tabName)
    {
        string xpath = $"//a[text()='{tabName}']";
        GetElement(By.XPath(xpath), 5).Click();
    }

    public string GetTabText()
    {
        string xpath = "//div[@role='tabpanel' and @aria-hidden='false']";
        return GetElement(By.XPath(xpath), 5).Text;        
    }

}
