using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests;
using System;



//[TestClass]
public class Common
{
    public static void GoToHomePage()
    {
        string xpath = "//header/a/img";
        BaseOperations.GetElement(xpath, 5).Click();
    }
    public static string GenerateRandom()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public static void ExpandLeftMenu(string menuName)
    {
        string xpath = $"//div[@class='header-text' and contains(text(),'{menuName}')]";
        if (!Validate.IsLeftMenuExpanded(menuName))
            BaseOperations.GetElement(xpath, 5).Click();
    }

    public static void ClickBlockInMainMenu(string menuBlock)
    {
        string xpath = $"//div[@class='card-body']//h5[contains(text(),'{menuBlock}')]";
        BaseOperations.GetElement(xpath, 5).Click();
    }


    public static void ClickOnSubMenu(string subMenuName)
    {
        string xpath = $"//ul[@class='menu-list']//span[contains(text(),'{subMenuName}')]";
        BaseOperations.GetElement(xpath, 5).Click();
    }

    public static void ClickButton(string buttonName)
    {
        string xpath = $"//button[contains(text(),'{buttonName}')]";
        BaseOperations.GetElement(xpath, 5).Click();
    }

    public static void ClickOnRadio(string radioName)
    {
        string xpath = $"//label[text()='{radioName}']//parent::div/input";
        BaseOperations.GetElement(xpath, 5).Click();

    }
    public static void CheckTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//span[@class='rct-checkbox']//*[local-name()='svg']";
        if (!Validate.IsTreeNodeChecked(treeNode))
            BaseOperations.GetElement(xpath, 5).Click();
    }

    public static void UnCheckTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//span[@class='rct-checkbox']//*[local-name()='svg']";
        if (Validate.IsTreeNodeChecked(treeNode))
            BaseOperations.GetElement(xpath, 5).Click();
    }

    public static void ExpandTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//parent::span//button//*[local-name()='svg']";
        if (!Validate.IsTreeNodeExpanded(treeNode))
            BaseOperations.GetElement(xpath, 5).Click();
    }




    public static void CollapseTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//parent::span//button//*[local-name()='svg']";
        if (Validate.IsTreeNodeExpanded(treeNode))
            BaseOperations.GetElement(xpath, 5).Click();
    }
    public class Validate
    {
        public static bool IsLeftMenuExpanded(string menuName)
        {
            string xpath = $"//div[@class='header-text' and contains(text(),'{menuName}')]//ancestor::div[@class='element-group']/child::div";
            string className = BaseOperations.GetElement(xpath, 5).GetAttribute("class");
            if (className == "element-list collapse show")
                return true;

            else return false;

        }

        public static bool IsTreeNodeExpanded(string treeNode)
        {
            string xpath = $"//span[text()='{treeNode}']//parent::label//parent::span//button//*[local-name()='svg']";
            string className = BaseOperations.GetElement(xpath, 5).GetAttribute("class");
            if (className == "rct-icon rct-icon-expand-open")
                return true;

            else return false;

        }
        public static bool IsTreeNodeChecked(string treeNode)
        {
            string xpath = $"//span[text()='{treeNode}']//parent::label//span[@class='rct-checkbox']//*[local-name()='svg']";
            string className = BaseOperations.GetElement(xpath, 5).GetAttribute("class");
            if (className == "rct-icon rct-icon-check")
                return true;

            else return false;

        }

        public static bool IsRadioDisabled(string radioName)
        {
            string xpath = $"//label[text()='{radioName}']//parent::div/input"; ;
            string attribute = BaseOperations.GetElement(xpath, 5).GetAttribute("disabled");
            if (attribute == "true")
                return true;

            else return false;

        }
    }
}

public class TextBox
{
    public static void InputTextField(string labelName, string inputText)
    {
        string xpath = $"//div/label[contains(text(),'{labelName}')]//parent::div//following-sibling::div/input";
        IWebElement element = BaseOperations.GetElement(xpath, 5);
        element.Clear();
        element.SendKeys(inputText);
    }
    public static void InputTextAreaField(string labelName, string inputText)
    {
        string xpath = $"//div/label[contains(text(),'{labelName}')]//parent::div//following-sibling::div/textarea";
        IWebElement element = BaseOperations.GetElement(xpath, 5);
        element.Clear();
        element.SendKeys(inputText);
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
            List<IWebElement> elements = BaseOperations.GetElements(xpath);
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







public class BaseOperations : TestBase
{

    //public static IWebDriver driver = TestBase.driver;

    public static void Wait(double waitSeconds)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitSeconds);
    }

    public static IWebElement GetElement(string xpath, int waitSeconds)
    {
        IWebElement element = null;
        for (; element == null && waitSeconds > 0; waitSeconds++)
        {
            element = driver.FindElement(By.XPath(xpath));
            ((IJavaScriptExecutor)driver)
        .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            //Console.WriteLine(element.Text);
        }
        return element;
    }

    public static List<IWebElement> GetElements(string xpath)
    {
        List<IWebElement> myElements = driver.FindElements(By.XPath(xpath)).ToList();
        ((IJavaScriptExecutor)driver)
    .ExecuteScript("arguments[0].scrollIntoView();", myElements.Last());
        return myElements;
    }


}