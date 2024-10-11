using OpenQA.Selenium;

public class TextBox : BaseOperations
{
    public TextBox(IWebDriver driver) : base(driver)
    {
    }

    private static string MakeXpathForTextField(string fieldName, bool isTextArea)
    {
        if (!isTextArea)
        {
            return $"//div/label[contains(text(),'{fieldName}')]//parent::div//following-sibling::div/input";

        }
        else return $"//div/label[contains(text(),'{fieldName}')]//parent::div//following-sibling::div/textarea";
    }

    public void InputFullName(string fullNameValue)
    {
        string xpath = MakeXpathForTextField("Full Name", false);
        InputTextField(By.XPath(xpath), fullNameValue);
    }

    public void InputEmail(string emailValue)
    {
        string xpath = MakeXpathForTextField("Email", false);
        InputTextField(By.XPath(xpath), emailValue);
    }

    public void InputCurrentAddress(string currentAddressValue)
    {
        string xpath = MakeXpathForTextField("Current Address", true);
        InputTextField(By.XPath(xpath), currentAddressValue);
    }

    public void InputPermanentAddress(string permanentAddressValue)
    {
        string xpath = MakeXpathForTextField("Permanent Address", true);
        InputTextField(By.XPath(xpath), permanentAddressValue);
    }

    public void ClickSubmit()
    {
        string xpath = "//button[text()='Submit']";
        ClickButton(By.XPath(xpath));
    }

    public Dictionary<string, string> GetOutputValues()
    {
        Dictionary<string, string> outputValues = new Dictionary<string, string>();
        string xpath = "//div[@id='output']/div/p";
        List<IWebElement> elements = GetElements(By.XPath(xpath), 5);
        foreach (IWebElement element in elements)
        {
            string elementText = element.Text;
            string[] results = elementText.Split(':');
            outputValues.Add(results[0].Trim(), results[1]);
        }
        return outputValues;
    }

    public bool IsEmailFieldMarkedRed()
    {
        string xpath = MakeXpathForTextField("Email", false);
        string classAttribute = GetElement(By.XPath(xpath), 5).GetAttribute("class");
        return classAttribute.Contains("error");
    }
}
