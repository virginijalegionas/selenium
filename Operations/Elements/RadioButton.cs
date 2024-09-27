using OpenQA.Selenium;
public class RadioButton : BaseOperations
{
    public RadioButton(IWebDriver driver) : base(driver)
    {
    }

    public void ClickOnYesRadio()
    {
        ClickOnRadio(By.Id("yesRadio"));

    }
    public void ClickOnImpressiveRadio()
    {
        ClickOnRadio(By.Id("impressiveRadio"));

    }
    public string GetWhichRadioSelected()
    {
        string xpath = $"//p[@class='mt-3']/span";
        return GetElement(By.XPath(xpath), 5).Text;
    }

    public bool IsRadioDisabled(string radioName)
    {
        string xpath = $"//label[text()='{radioName}']//parent::div/input"; ;
        string attribute = GetElement(By.XPath(xpath), 5).GetAttribute("disabled");
        if (attribute == "true")
            return true;

        else return false;

    }

}


