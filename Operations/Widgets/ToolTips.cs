using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

public class ToolTips : BaseOperations
{
    public ToolTips(IWebDriver driver) : base(driver)
    {
    }

    public string GetButtonToolTip()
    {
        IWebElement hoverButton = GetElement(By.Id("toolTipButton"), 5);
        Actions toolTip = new Actions(driver);
        toolTip.MoveToElement(hoverButton);
        toolTip.Build().Perform();
        Common.Wait(2);
        return GetElement(By.Id("buttonToolTip"), 5).Text;
    }

    public string GetTextFieldToolTip()
    {
        IWebElement hoverTextField = GetElement(By.Id("toolTipTextField"), 5);
        Actions toolTip = new Actions(driver);
        toolTip.MoveToElement(hoverTextField);
        toolTip.Build().Perform();
        Common.Wait(2);
        return GetElement(By.Id("textFieldToolTip"), 5).Text;
    }

}