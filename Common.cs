using SeleniumTests;
using OpenQA.Selenium;



public class Common : TestBase
{
    public static void GoToHomePage()
    {
        string xpath = "//header/a/img";
        BaseOperations.GetElement(By.XPath(xpath), 5).Click();
    }
    public static string GenerateRandom()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static void InputTextField(string labelName, string inputText)
    {
        string xpath = $"//div/label[contains(text(),'{labelName}')]//parent::div//following-sibling::div/input";
        IWebElement element = BaseOperations.GetElement(By.XPath(xpath), 5);
        element.Clear();
        element.SendKeys(inputText);
    }
    public static void InputTextAreaField(string labelName, string inputText)
    {
        string xpath = $"//div/label[contains(text(),'{labelName}')]//parent::div//following-sibling::div/textarea";
        IWebElement element = BaseOperations.GetElement(By.XPath(xpath), 5);
        element.Clear();
        element.SendKeys(inputText);
    }
    public static void ExpandLeftMenu(string menuName)
    {
        string xpath = $"//div[@class='header-text' and contains(text(),'{menuName}')]";
        if (!Validate.IsLeftMenuExpanded(menuName))
            BaseOperations.GetElement(By.XPath(xpath), 5).Click();
    }

    public static void ClickBlockInMainMenu(string menuBlock)
    {
        string xpath = $"//div[@class='card-body']//h5[contains(text(),'{menuBlock}')]";
        BaseOperations.GetElement(By.XPath(xpath), 5).Click();
    }


    public static void ClickOnSubMenu(string subMenuName)
    {
        string xpath = $"//ul[@class='menu-list']//span[contains(text(),'{subMenuName}')]";
        BaseOperations.GetElement(By.XPath(xpath), 5).Click();
    }

    public static void ClickButton(string buttonName)
    {
        string xpath = $"//button[text()='{buttonName}']";
        BaseOperations.GetElement(By.XPath(xpath), 5).Click();
    }





    public class Validate
    {
        public static bool IsLeftMenuExpanded(string menuName)
        {
            string xpath = $"//div[@class='header-text' and contains(text(),'{menuName}')]//ancestor::div[@class='element-group']/child::div";
            string className = BaseOperations.GetElement(By.XPath(xpath), 5).GetAttribute("class");
            if (className == "element-list collapse show")
                return true;

            else return false;

        }


    }
}







