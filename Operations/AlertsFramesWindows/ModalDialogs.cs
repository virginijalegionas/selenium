using OpenQA.Selenium;

public class ModalDialogs : BaseOperations
{
    public ModalDialogs(IWebDriver driver) : base(driver)
    {
    }

    public void ClickSmallModalButton()
    {
        ClickButton(By.Id("showSmallModal"));
    }

    public void ClickLargeModalButton()
    {
        ClickButton(By.Id("showLargeModal"));
    }

    public void ClickCloseButton()
    {
        ClickButton(By.XPath("//button[text()='Close']"));
    }

    public void ClickXButton()
    {
        ClickX();
    }

    public string GetModalTitle()
    {
        string xpath = $"//div[@class='modal-title h4']";
        return GetElement(By.XPath(xpath), 5).Text;
    }

    public string GetLargeModalBody()
    {
        string xpath = $"//div[@class='modal-body']/p";
        return GetElement(By.XPath(xpath), 5).Text;
    }

    public string GetSmallModalBody()
    {
        string xpath = $"//div[@class='modal-body']";
        return GetElement(By.XPath(xpath), 5).Text;
    }
}
