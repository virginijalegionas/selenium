using OpenQA.Selenium;

public class CheckBox : BaseOperations
{
    public CheckBox(IWebDriver driver) : base(driver)
    {
    }

    public void CheckTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//span[@class='rct-checkbox']//*[local-name()='svg']";
        if (GetNodeCheckedStatus(treeNode) == "unchecked" || GetNodeCheckedStatus(treeNode) == "half checked")
            GetElement(By.XPath(xpath), 5).Click();
    }

    public void UnCheckTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//span[@class='rct-checkbox']//*[local-name()='svg']";
        if (GetNodeCheckedStatus(treeNode) == "checked")
            GetElement(By.XPath(xpath), 5).Click();
    }

    public void ExpandTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//parent::span//button//*[local-name()='svg']";
        if (!IsTreeNodeExpanded(treeNode))
            GetElement(By.XPath(xpath), 5).Click();
    }

    public void CollapseTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//parent::span//button//*[local-name()='svg']";
        if (IsTreeNodeExpanded(treeNode))
            GetElement(By.XPath(xpath), 5).Click();
    }

    public bool IsTreeNodeExpanded(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//parent::span//button//*[local-name()='svg']";
        string className = GetElement(By.XPath(xpath), 5).GetAttribute("class");
        if (className == "rct-icon rct-icon-expand-open")
            return true;
        else return false;
    }

    public string GetNodeCheckedStatus(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//span[@class='rct-checkbox']//*[local-name()='svg']";
        string className = GetElement(By.XPath(xpath), 5).GetAttribute("class");
        if (className.Contains("rct-icon rct-icon-check")) return "checked";
        else if (className.Contains("rct-icon rct-icon-uncheck")) return "unchecked";
        else return "half checked";
    }
}
