using OpenQA.Selenium;

public class UploadDownload : BaseOperations
{
    public UploadDownload(IWebDriver driver) : base(driver)
    {
    }

    public void UploadFile(string fileName)
    {
        UploadTestFile(By.Id("uploadFile"), fileName);
    }

    public string GetUploadedFilePath()
    {
        return GetElement(By.Id("uploadedFilePath"), 5).Text;
    }

    public void ClickDownloadButton()
    {
        ClickButton(By.Id("downloadButton"));
    }
}
