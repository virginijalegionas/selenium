using OpenQA.Selenium;


public class NestedFrames : BaseOperations
{
    public NestedFrames(IWebDriver driver) : base(driver)
    {
    }

    public void SwitchToParentFrame()
    {
        IWebElement iframe = GetElement(By.Id("frame1"), 5);
        driver.SwitchTo().Frame(iframe);
    }

    public void SwitchToChildFrame()
    {
        string xpath = "//iframe[@srcdoc = '<p>Child Iframe</p>']";
        IWebElement iframe = GetElement(By.XPath(xpath), 5);
        driver.SwitchTo().Frame(iframe);
    }

    public string GetParentFrameText()
    {
        string xpath = $"//body";
        return GetElement(By.XPath(xpath), 5).Text;
    }

    public string GetChildFrameText()
    {
        string xpath = $"//body/p";
        return GetElement(By.XPath(xpath), 5).Text;
    }

}
