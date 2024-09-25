using OpenQA.Selenium;

public class CheckBox
{
    public static void CheckTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//span[@class='rct-checkbox']//*[local-name()='svg']";
        if (!Validate.IsTreeNodeChecked(treeNode))
            BaseOperations.GetElement(By.XPath(xpath), 5).Click();
    }

    public static void UnCheckTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//span[@class='rct-checkbox']//*[local-name()='svg']";
        if (Validate.IsTreeNodeChecked(treeNode))
            BaseOperations.GetElement(By.XPath(xpath), 5).Click();
    }

    public static void ExpandTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//parent::span//button//*[local-name()='svg']";
        if (!Validate.IsTreeNodeExpanded(treeNode))
            BaseOperations.GetElement(By.XPath(xpath), 5).Click();
    }




    public static void CollapseTreeNode(string treeNode)
    {
        string xpath = $"//span[text()='{treeNode}']//parent::label//parent::span//button//*[local-name()='svg']";
        if (Validate.IsTreeNodeExpanded(treeNode))
            BaseOperations.GetElement(By.XPath(xpath), 5).Click();
    }

    public class Validate
    {
        public static bool IsTreeNodeExpanded(string treeNode)
        {
            string xpath = $"//span[text()='{treeNode}']//parent::label//parent::span//button//*[local-name()='svg']";
            string className = BaseOperations.GetElement(By.XPath(xpath), 5).GetAttribute("class");
            if (className == "rct-icon rct-icon-expand-open")
                return true;

            else return false;

        }
        public static bool IsTreeNodeChecked(string treeNode)
        {
            string xpath = $"//span[text()='{treeNode}']//parent::label//span[@class='rct-checkbox']//*[local-name()='svg']";
            string className = BaseOperations.GetElement(By.XPath(xpath), 5).GetAttribute("class");
            if (className == "rct-icon rct-icon-check")
                return true;

            else return false;

        }
    }

}
