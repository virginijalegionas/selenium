using OpenQA.Selenium;

public class WebTables : BaseOperations
{
    public WebTables(IWebDriver driver) : base(driver)
    {
    }

    public void ClickAddButton()
    {
        string xpath = "//button[text()='Add']";
        ClickButton(By.XPath(xpath));
    }

    public void ClickEditByNameButton(string name)
    {
        string xpath = $"//div//div[text()='{name}']//parent::div//span[@title='Edit']";
        ClickButton(By.XPath(xpath));
    }

    public void ClickDeleteByNameButton(string name)
    {
        string xpath = $"//div//div[text()='{name}']//parent::div//span[@title='Delete']";
        ClickButton(By.XPath(xpath));
    }

    public void ClickXButton()
    {
        ClickX();
    }

    public void ClickSubmitButton()
    {
        string xpath = "//button[text()='Submit']";
        ClickButton(By.XPath(xpath));
    }

    private static string MakeXpathForTextField(string fieldName)
    {
        return $"//div/label[contains(text(),'{fieldName}')]//parent::div//following-sibling::div/input";
    }

    public void InputEmail(string emailValue)
    {
        string xpath = MakeXpathForTextField("Email");
        InputTextField(By.XPath(xpath), emailValue);
    }

    public void InputFirstName(string firstNameValue)
    {
        string xpath = MakeXpathForTextField("First Name");
        InputTextField(By.XPath(xpath), firstNameValue);

    }

    public void InputLastName(string lastNameValue)
    {
        string xpath = MakeXpathForTextField("Last Name");
        InputTextField(By.XPath(xpath), lastNameValue);
    }

    public void InputAge(string ageValue)
    {
        string xpath = MakeXpathForTextField("Age");
        InputTextField(By.XPath(xpath), ageValue);
    }

    public void InputSalary(string salaryValue)
    {
        string xpath = MakeXpathForTextField("Salary");
        InputTextField(By.XPath(xpath), salaryValue);
    }

    public void InputDepartment(string departmentValue)
    {
        string xpath = MakeXpathForTextField("Department");
        InputTextField(By.XPath(xpath), departmentValue);
    }

    public List<Dictionary<string, string>> GetTableValues()
    {
        string headerNameXpath = $"//div[@class='rt-thead -header']//div[@class='rt-resizable-header-content']";
        List<IWebElement> headerElements = GetElements(By.XPath(headerNameXpath), 5);


        string rowsXpath = $"//div[@class='rt-tr-group']/div[@role = 'row']";
        List<IWebElement> rowElements = GetElements(By.XPath(rowsXpath), 5);
        List<Dictionary<string, string>> tableValues = [];
        foreach (IWebElement row in rowElements)
        {
            List<IWebElement> rowValues = row.FindElements(By.TagName("div")).ToList();
            Dictionary<string, string> rowData = [];
            if (rowValues[0].Text[0] != 32)
            {
                for (int b = 0; b < headerElements.Count; b++)
                {
                    rowData[headerElements[b].Text] = rowValues[b].Text;
                }
            }
            if (rowData.Count > 0)
            {
                tableValues.Add(rowData);
            }
        }
        return tableValues;
    }
}

