using OpenQA.Selenium;
public class RadioButtons
{
    public static void ClickOnRadio(string radioName)
    {
        string xpath = $"//label[text()='{radioName}']//parent::div/input";
        BaseOperations.GetElement(By.XPath(xpath), 5).Click();

    }

    public class Validate
    {
        public static string GetWhichRadioSelected()
        {
            string xpath = $"//p[@class='mt-3']/span";
            return BaseOperations.GetElement(By.XPath(xpath), 5).Text;
        }

        public static bool IsRadioDisabled(string radioName)
        {
            string xpath = $"//label[text()='{radioName}']//parent::div/input"; ;
            string attribute = BaseOperations.GetElement(By.XPath(xpath), 5).GetAttribute("disabled");
            if (attribute == "true")
                return true;

            else return false;

        }

    }

}


