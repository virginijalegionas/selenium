using OpenQA.Selenium;

public class Alerts : BaseOperations
{
    public Alerts(IWebDriver driver) : base(driver)
    {
    }

    public void ClickForAlert()
    {
        string xpath = $"//span[text()='Click Button to see alert ']//parent::div//following-sibling::div/button";
        ClickButton(By.XPath(xpath));
    }

    public void ClickForAlertIn5Seconds()
    {
        string xpath = $"//span[text()='On button click, alert will appear after 5 seconds ']//parent::div//following-sibling::div/button";
        ClickButton(By.XPath(xpath));
    }

    public void ClickForConfirmBox()
    {
        string xpath = $"//span[text()='On button click, confirm box will appear']//parent::div//following-sibling::div/button";
        ClickButton(By.XPath(xpath));
    }
    public void ClickForPromptBox()
    {
        string xpath = $"//span[text()='On button click, prompt box will appear']//parent::div//following-sibling::div/button";
        ClickButton(By.XPath(xpath));
    }

    public string GetValueSelectedInConfirmBox()
    {
        string xpath = $"//span[text()='On button click, confirm box will appear']//following-sibling::span";
        return GetElement(By.XPath(xpath), 5).Text;
    }

    public string GetValueEnteredInPromtBox()
    {
        string xpath = $"//span[text()='On button click, prompt box will appear']//following-sibling::span";
        return GetElement(By.XPath(xpath), 5).Text;
    }

    public void AcceptAlert()
    {
        IAlert alert = driver.SwitchTo().Alert();
        alert.Accept();
    }

    public void DismissAlert()
    {
        IAlert alert = driver.SwitchTo().Alert();
        alert.Dismiss();
    }

    public string GetAlertText()
    {
        IAlert alert = driver.SwitchTo().Alert();
        return alert.Text;
    }

    public void InputTextIntoAllert(string text)
    {
        IAlert alert = driver.SwitchTo().Alert();
        alert.SendKeys(text);
    }

    public bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }
}
