//using OpenQA.Selenium;


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

    //not WORKING, NEEN TO LOOK FOR SOLUTION: 
    //element click intercepted: Element <span class="sr-only">...</span> is not clickable at point (1342, 44). 
    //Other element would receive the click: <span aria-hidden="true">...</span>
    public void ClickXButton()
    {
        string xpath = $"//button//span[text()='Close']";
        ClickButton(By.XPath(xpath));
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
    public void InputAgeName(string ageValue)
    {
        string xpath = MakeXpathForTextField("Age");
        InputTextField(By.XPath(xpath), ageValue);
    }
    public void InputSalaryName(string salaryValue)
    {
        string xpath = MakeXpathForTextField("Salary");
        InputTextField(By.XPath(xpath), salaryValue);
    }
    public void InputDepartmentName(string departmentValue)
    {
        string xpath = MakeXpathForTextField("Department");
        InputTextField(By.XPath(xpath), departmentValue);
    }




    /* public static List<Dictionary<string, string>> GetTableValues()
    {
        string columnNameXpath = $"//div[@class='rt-thead -header']//div[@class='rt-resizable-header-content']";
        List<IWebElement> columnElements = BaseOperations.GetElements(By.XPath(columnNameXpath), 5);


        string valueRowsXpath = $"//div[@class='rt-tr-group']/div[@role = 'row']";
        List<IWebElement> rowElements = BaseOperations.GetElements(By.XPath(valueRowsXpath), 5);
        List<Dictionary<string, string>> tableValues = [];
        foreach (IWebElement row in rowElements)
        {
            List<IWebElement> rowValues = row.FindElements(By.TagName("div")).ToList();
            Dictionary<string, string> allCellsInARow = [];
            foreach (IWebElement cell in rowValues)
            {
                foreach (IWebElement columnElemnt in columnElements)
                {
                    allCellsInARow.Add(columnElemnt.Text, cell.Text);
                }
            }
            tableValues.Add(allCellsInARow);
        }

        return tableValues;
    } */



}



