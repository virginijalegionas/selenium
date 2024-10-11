using OpenQA.Selenium;

public class DynamicProperties : BaseOperations
{
    public DynamicProperties(IWebDriver driver) : base(driver)
    {
    }

    public bool IsButtonVisible(string buttonName)
    {
        string xpath = $"//button[text()='{buttonName}']";
        return IsElementExists(By.XPath(xpath), 3);
    }

    public bool IsButtonDisabled(string buttonName)
    {
        string xpath = $"//button[text()='{buttonName}']"; ;
        return IsElementDisabled(By.XPath(xpath));
    }

    public string GetColorChangeButtonClass()
    {
        return GetElement(By.Id("colorChange"), 5).GetAttribute("class");
    }
}