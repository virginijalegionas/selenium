using OpenQA.Selenium;

public class ProgressBar : BaseOperations
{
    public ProgressBar(IWebDriver driver) : base(driver)
    {
    }
    public void ClickStartStopButton()
    {
        ClickButton(By.Id("startStopButton"));
    }

    public string GetProgressBarValue()
    {
        return GetElement(By.XPath("//div[@role='progressbar']"), 5).GetAttribute("aria-valuenow");
    }
}