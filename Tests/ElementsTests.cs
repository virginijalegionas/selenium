namespace SeleniumTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


[TestClass]
public class ElementsTests : TestBase
{
    [TestInitialize]

    public void AutoStartDriver()
    {
        StartDriver();
        OpenUrl();
    }


    [TestMethod]
    public void TextBox_FillAllValuesIn()
    {
        Common.ClickBlockInMainMenu("Elements");
        Assert.IsTrue(Common.Validate.IsLeftMenuExpanded("Elements"), $"Expexted that Elements Menu on the left is expanded");
        Common.ClickOnSubMenu("Text Box");
        string myName = $"name {Common.GenerateRandom()}";
        string myEmail = $"email@mail.com";
        string myCurrentAddress = $"currAddr {Common.GenerateRandom()}";
        string myPermanentAddress = $"perAddr {Common.GenerateRandom()}";
        TextBox.InputTextField("Full Name", myName);
        TextBox.InputTextField("Email", myEmail);
        TextBox.InputTextAreaField("Current Address", myCurrentAddress);
        TextBox.InputTextAreaField("Permanent Address", myPermanentAddress);
        TextBox.ClickSubmit();

        Dictionary<string, string> outputValues = TextBox.Validate.GetOutputValues();
        Assert.AreEqual(myName, outputValues["Name"], $"Expected Name value to be: {myName}");
        Assert.AreEqual(myEmail, outputValues["Email"], $"Expected Email value to be: {myEmail}");
        Assert.AreEqual(myCurrentAddress, outputValues["Current Address"], $"Expected Current Address value to be: {myCurrentAddress}");
        Assert.AreEqual(myPermanentAddress, outputValues["Permananet Address"], $"Expected Permanant Address value to be: {myPermanentAddress}");

    }


    [TestMethod]
    public void CheckBox_CheckUncheckNodes()
    {
        Common.ClickBlockInMainMenu("Elements");
        Common.ClickOnSubMenu("Check Box");

        Common.ExpandTreeNode("Home");
        Common.ExpandTreeNode("Desktop");
        Common.CheckTreeNode("Notes");
        Common.CheckTreeNode("Documents");




    }
    [TestMethod]
    public void RadioButton()
    {
        Common.ClickBlockInMainMenu("Elements");
        Common.ClickOnSubMenu("Radio Button");

        Assert.IsFalse(Common.Validate.IsRadioDisabled("Yes"), $"Expected 'Yes' radio to be enabled ");
        Assert.IsTrue(Common.Validate.IsRadioDisabled("No"), $"Expected 'No' radio to be disabled");



    }
}