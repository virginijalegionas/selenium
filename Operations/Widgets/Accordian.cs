using OpenQA.Selenium;

public class Accordian : BaseOperations
{
    public Accordian(IWebDriver driver) : base(driver)
    {
    }

    public void ExpandAccordian(string accordianValue)
    {
        if (!IsAccordianExpanded(accordianValue))
        {
            string xpath = $"//div[@class='card-header' and text()='{accordianValue}']";
            GetElement(By.XPath(xpath), 5).Click();
        }
    }

    public bool IsAccordianExpanded(string accordianValue)
    {
        string xpath = $"//div[@class='card-header' and text()='{accordianValue}']//following-sibling::div";
        string classValue = GetElement(By.XPath(xpath), 5).GetAttribute("class");
        return classValue == "collapse show";
    }

    public string GetExpandedAccordianText()
    {
        string xpath = "//div[@class='card-body']//parent::div[@class = 'collapse show']";
        return GetElement(By.XPath(xpath), 5).Text;
    }
}