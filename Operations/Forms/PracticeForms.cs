using OpenQA.Selenium;


public class PracticeForms : BaseOperations
{
    public PracticeForms(IWebDriver driver) : base(driver)
    {
    }


/* private static string MakeXpathForTextField(string fieldName, bool isTextArea){
    if (!isTextArea){
        return $"//div/label[contains(text(),'{fieldName}')]//parent::div//following-sibling::div/input";

    }
    else  return $"//div/label[contains(text(),'{fieldName}')]//parent::div//following-sibling::div/textarea";

} */
    public void InputFirstName(string firstNameValue)
    {        
        InputTextField(By.Id("firstName"), firstNameValue);
    }
    public void InputLastName(string lastNameValue)
    {        
        InputTextField(By.Id("lastName"), lastNameValue);
    }

     public void InputEmail(string emailValue)
    {       
        InputTextField(By.Id("userEmail"), emailValue);
    }
public void InputMobile(string mobileNumber)
    {       
        InputTextField(By.Id("userNumber"), mobileNumber);
    }

//ToDO later might overlap
public void SelectGender(string gender)
    {       
        
    }

    
    public void InputCurrentAddress(string currentAddressValue)
    {
        InputTextField(By.Id("currentAddress"), currentAddressValue);
    }

    public void SelectHobby(string hobby)
    {
        string xpath = $"//label[text()='{hobby}']//preceding-sibling::input";
        GetElement(By.XPath(xpath), 5).Click();
    }

/*    public void ClickSubmit()
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
 */
   

}
