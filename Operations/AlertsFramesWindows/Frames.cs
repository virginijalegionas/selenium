using OpenQA.Selenium;

public class Frames : BaseOperations
{
    public Frames(IWebDriver driver) : base(driver)
    {
    }

    public void SwitchToFrameOne()
    {
        IWebElement iframe = GetElement(By.Id("frame1"), 5);
        driver.SwitchTo().Frame(iframe);
    }

    public void SwitchToFrameTwo()
    {
        IWebElement iframe = GetElement(By.Id("frame2"), 5);
        driver.SwitchTo().Frame(iframe);
    }

    public void SwitchToMainFrame()
    {
        driver.SwitchTo().ParentFrame();

    }

    public string GetSampleHeadingInFrame()
    {
        string xpath = $"//h1[@id = 'sampleHeading']";
        return GetElement(By.XPath(xpath), 5).Text;
    }
}
