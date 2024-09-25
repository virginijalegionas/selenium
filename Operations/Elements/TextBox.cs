using OpenQA.Selenium;


public class TextBox
{
    public static void InputFullName(string fullNameValue)
    {
        string xpath = $"//div/label[contains(text(),'Full Name')]//parent::div//following-sibling::div/input";
        Common.InputTextField(xpath, fullNameValue);
    }

    public static void InputEmail(string emailValue)
    {
        string xpath = $"//div/label[contains(text(),'Email')]//parent::div//following-sibling::div/input";
        Common.InputTextField(xpath, emailValue);
    }
    public static void InputCurrentAddress(string currentAddressValue)
    {
        string xpath = $"//div/label[contains(text(),'Current Address')]//parent::div//following-sibling::div/input";
        Common.InputTextAreaField(xpath, currentAddressValue);
    }

    public static void InputPermanentAddress(string permanentAddressValue)
    {
        string xpath = $"//div/label[contains(text(),'Permanent Address')]//parent::div//following-sibling::div/input";
        Common.InputTextAreaField(xpath, permanentAddressValue);
    }

    public static void ClickSubmit()
    {
        Common.ClickButton("Submit");
    }

    public class Validate
    {
        public static Dictionary<string, string> GetOutputValues()
        {
            Dictionary<string, string> outputValues = new Dictionary<string, string>();
            string xpath = "//div[@id='output']/div/p";
            List<IWebElement> elements = BaseOperations.GetElements(By.XPath(xpath), 5);
            foreach (IWebElement element in elements)
            {
                string elementText = element.Text;
                string[] results = elementText.Split(':');
                outputValues.Add(results[0].Trim(), results[1]);
            }

            return outputValues;
        }

    }

}
