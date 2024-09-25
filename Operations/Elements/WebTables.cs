//using OpenQA.Selenium;


using OpenQA.Selenium;

public class WebTables
{

    public static void ClickAddButton()
    {
        Common.ClickButton("Add");
    }

    public static void ClickEditByNameButton(string name)
    {
        string xpath = $"//div//div[text()='{name}']//parent::div//span[@title='Edit']";
        BaseOperations.GetElement(By.XPath(xpath), 5).Click();

    }


    public static void ClickDeleteByNameButton(string name)
    {
        string xpath = $"//div//div[text()='{name}']//parent::div//span[@title='Delete']";
        BaseOperations.GetElement(By.XPath(xpath), 5).Click();
    }

    public class Edit
    {

        //not WORKING, NEEN TO LOOK FOR SOLUTION: 
        //element click intercepted: Element <span class="sr-only">...</span> is not clickable at point (1342, 44). 
        //Other element would receive the click: <span aria-hidden="true">...</span>
        public static void ClickXButton()
        {
            string xpath = $"//button//span[text()='Close']";
            BaseOperations.GetElement(By.XPath(xpath), 5).Click();
        }
        public static void ClickSubmitButton()
        {
            Common.ClickButton("Submit");
        }
        public static void InputEmail(string emailValue)
        {
            string xpath = $"//div/label[contains(text(),'Email')]//parent::div//following-sibling::div/input";
            Common.InputTextField(xpath, emailValue);
        }
        public static void InputFirstName(string firstNameValue)
        {
            string xpath = $"//div/label[contains(text(),'First Name')]//parent::div//following-sibling::div/input";
            Common.InputTextField(xpath, firstNameValue);
        }
        public static void InputLastName(string lastNameValue)
        {
            string xpath = $"//div/label[contains(text(),'First Name')]//parent::div//following-sibling::div/input";
            Common.InputTextField(xpath, lastNameValue);
        }
        public static void InputAgeName(string ageValue)
        {
            string xpath = $"//div/label[contains(text(),'Age')]//parent::div//following-sibling::div/input";
            Common.InputTextField(xpath, ageValue);
        }
        public static void InputSalaryName(string salaryValue)
        {
            string xpath = $"//div/label[contains(text(),'Salary')]//parent::div//following-sibling::div/input";
            Common.InputTextField(xpath, salaryValue);
        }
        public static void InputDepartmentName(string departmentValue)
        {
            string xpath = $"//div/label[contains(text(),'Department')]//parent::div//following-sibling::div/input";
            Common.InputTextField(xpath, departmentValue);
        }
    }

    public class Add : Edit
    {

    }

    public class Validate
    {
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


}



