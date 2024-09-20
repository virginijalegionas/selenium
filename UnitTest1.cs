namespace SeleniumTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;



[TestClass]
public class UnitTest1 : TestBase
{
    [TestInitialize]

    public void AutoStartDriver()
    {
        StartDriver();
        OpenUrl();
    }


    [TestMethod]
    public void TestMethod1()
    {

        string xpath = "//div[@class='card-body']//h5[contains(text(),'Elements')]";
        BaseOperations.click(xpath, 5);


        BaseOperations.click("//ul[@class='menu-list']//span[contains(text(),'Text Box')]", 5);

    }
}