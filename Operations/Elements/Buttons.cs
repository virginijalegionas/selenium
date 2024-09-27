using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTests;


public class Buttons : BaseOperations
{


    public Buttons(IWebDriver driver) : base(driver)
    {
    }

    public void ClickClickMeButton()
    {
        string xpath = "//button[text()='Click Me']";
        ClickButton(By.XPath(xpath));
    }
    public void ClickRightClickMeButton()
    {
        string xpath = $"//button[text()='Right Click Me']";
        RightClickButton(By.XPath(xpath));
    }
    public void ClickDoubleClickMeButton()
    {
        string xpath = $"//button[text()='Double Click Me']";
        DoubleClickButton(By.XPath(xpath));
    }

    public string GetClickMessage()
    {
        string xpath = $"//p[@id='dynamicClickMessage']";
        return GetElement(By.XPath(xpath), 5).Text;
    }

    public string GetDoubleClickMessage()
    {
        string xpath = $"//p[@id='doubleClickMessage']";
        return GetElement(By.XPath(xpath), 5).Text;
    }
    public string GetRightClickMessage()
    {
        string xpath = $"//p[@id='rightClickMessage']";
        return GetElement(By.XPath(xpath), 5).Text;
    }

}
