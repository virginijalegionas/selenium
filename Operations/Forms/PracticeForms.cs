using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


public class PracticeForms : BaseOperations
{
    public PracticeForms(IWebDriver driver) : base(driver)
    {
    }

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

    public void SelectGender(string gender)
    {
        string xpath = $"//label[text()='{gender}']//preceding-sibling::input";
        ClickOnRadio(By.XPath(xpath));
    }

    public void SelectSubjects(string subjectValue)
    {
        string xpath = $"//div[@id='subjectsContainer']//input";
        string searchString = subjectValue[..2];
        InputTextField(By.XPath(xpath), searchString);
        string dropDownXpath = $"//div[contains(text(),'{subjectValue}')]";
        GetElement(By.XPath(dropDownXpath), 5).Click();
    }

    public void SelectState(string stateValue)
    {
        GetElement(By.Id("state"), 5).Click();
        string dropDownXpath = $"//div[contains(text(),'{stateValue}')]";
        GetElement(By.XPath(dropDownXpath), 5).Click();
    }

    public void SelectCity(string cityValue)
    {
        GetElement(By.Id("city"), 5).Click();
        string dropDownXpath = $"//div[contains(text(),'{cityValue}')]";
        GetElement(By.XPath(dropDownXpath), 5).Click();
    }

    public void InputCurrentAddress(string currentAddressValue)
    {
        InputTextField(By.Id("currentAddress"), currentAddressValue);
    }

    public void SelectHobby(string hobby)
    {
        string xpath = $"//label[text()='{hobby}']//preceding-sibling::input";
        ClickOnCheckBox(By.XPath(xpath));
    }

    public void SelectDateOfBirth(string year, string month, string day)
    {

        SelectDateFromPicker(year, month, day);
    }


    public void ClickSubmit()
    {
        string xpath = "//button[text()='Submit']";
        ClickButton(By.XPath(xpath));
    }
    public void UploadFile(string fileName)
    {

        UploadTestFile(By.Id("uploadPicture"), fileName);
    }

    public void ClickClose()
    {
        ClickButton(By.Id("closeLargeModal"));
    }

    public Dictionary<string, string> GetSubmitValues()
    {
        Dictionary<string, string> submitValues = new Dictionary<string, string>();
        string rowXpath = "//table//tbody/tr";
        List<IWebElement> rows = GetElements(By.XPath(rowXpath), 5);
        foreach (IWebElement row in rows)
        {

            List<IWebElement> columns = row.FindElements(By.TagName("td")).ToList();
            submitValues.Add(columns[0].Text, columns[1].Text);
        }

        return submitValues;
    }



}
