using System.Net;
using OpenQA.Selenium;
public class UploadDownload : BaseOperations
{
    public UploadDownload(IWebDriver driver) : base(driver)
    {
    }

    public void UploadTestFile()
    {
        string fullPath = System.Reflection.Assembly.GetAssembly(typeof(UploadDownload)).Location;
        string theDirectory = Path.GetDirectoryName(fullPath);

        string uploadFile = Path.Combine(theDirectory, "TestUpload.txt");
        IWebElement fileInput = driver.FindElement(By.Id("uploadFile"));
        fileInput.SendKeys(uploadFile);
        //driver.FindElement(By.Id("file-submit")).Click();
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


