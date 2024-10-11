using OpenQA.Selenium;

public class LeftPanel
{
    private BaseOperations baseOperations;

    public LeftPanel(BaseOperations baseOperations)
    {
        this.baseOperations = baseOperations;
    }

    public void ExpandLeftMenu(string menuName)
    {
        string xpath = $"//div[@class='header-text' and contains(text(),'{menuName}')]";
        if (!IsLeftMenuExpanded(menuName))
            baseOperations.GetElement(By.XPath(xpath), 5).Click();
    }

    public void CollapseLeftMenu(string menuName)
    {
        string xpath = $"//div[@class='header-text' and contains(text(),'{menuName}')]";
        if (IsLeftMenuExpanded(menuName))
            baseOperations.GetElement(By.XPath(xpath), 5).Click();
    }

    public void ClickOnSubMenu(string subMenuName)
    {
        string xpath = $"//ul[@class='menu-list']//span[contains(text(),'{subMenuName}')]";
        baseOperations.GetElement(By.XPath(xpath), 5).Click();
    }

    public bool IsLeftMenuExpanded(string menuName)
    {
        string xpath = $"//div[@class='header-text' and contains(text(),'{menuName}')]//ancestor::div[@class='element-group']/child::div";
        string className = baseOperations.GetElement(By.XPath(xpath), 5).GetAttribute("class");
        if (className == "element-list collapse show")
        {
            return true;
        }
        else return false;
    }
}
