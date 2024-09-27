using OpenQA.Selenium;



public class MainPageMenu
{

    private BaseOperations baseOperations;

    public MainPageMenu(BaseOperations baseOperations)
    {
        this.baseOperations = baseOperations;
    }

    public void ClickOnBlock(string menuBlock)
    {
        string xpath = $"//div[@class='card-body']//h5[contains(text(),'{menuBlock}')]";
        baseOperations.GetElement(By.XPath(xpath), 5).Click();
    }

}
