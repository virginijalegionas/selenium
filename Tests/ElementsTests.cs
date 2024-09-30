namespace SeleniumTests;



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
        TextBox textBox = new TextBox(driver);
        textBox.MainPageMenu.ClickOnBlock("Elements");
        textBox.LeftPanel.ClickOnSubMenu("Text Box");

        string myName = $"name {Common.GenerateRandom()}";
        string myEmail = $"email@mail.com";
        string myCurrentAddress = $"currAddr {Common.GenerateRandom()}";
        string myPermanentAddress = $"perAddr {Common.GenerateRandom()}";
        textBox.InputFullName(myName);
        textBox.InputEmail(myEmail);
        textBox.InputCurrentAddress(myCurrentAddress);
        textBox.InputPermanentAddress(myPermanentAddress);
        textBox.ClickSubmit();

        Dictionary<string, string> outputValues = textBox.GetOutputValues();
        Assert.AreEqual(myName, outputValues["Name"], $"Expected Name value to be: {myName}");
        Assert.AreEqual(myEmail, outputValues["Email"], $"Expected Email value to be: {myEmail}");
        Assert.AreEqual(myCurrentAddress, outputValues["Current Address"], $"Expected Current Address value to be: {myCurrentAddress}");
        Assert.AreEqual(myPermanentAddress, outputValues["Permananet Address"], $"Expected Permanant Address value to be: {myPermanentAddress}");

    }

    //TODO: test is not finished
    [TestMethod]
    public void CheckBox_CheckUncheckNodes()
    {
        CheckBox checkBox = new CheckBox(driver);
        checkBox.MainPageMenu.ClickOnBlock("Elements");
        checkBox.LeftPanel.ClickOnSubMenu("Check Box");

        checkBox.ExpandTreeNode("Home");
        checkBox.ExpandTreeNode("Desktop");
        checkBox.CheckTreeNode("Notes");
        checkBox.CheckTreeNode("Documents");

    }

    //TODO overlaping elements look into it
    [TestMethod]
    public void RadioButton()
    {
        RadioButton radioButton = new RadioButton(driver);
        radioButton.MainPageMenu.ClickOnBlock("Elements");
        radioButton.LeftPanel.ClickOnSubMenu("Radio Button");

        Assert.IsFalse(radioButton.IsRadioDisabled("Yes"), $"Expected 'Yes' radio to be enabled ");
        Assert.IsTrue(radioButton.IsRadioDisabled("No"), $"Expected 'No' radio to be disabled");
        radioButton.ClickOnImpressiveRadio();
        Assert.AreEqual("Impressive", radioButton.GetWhichRadioSelected(), $"Expected, that Impressive radio is selected");
        radioButton.ClickOnYesRadio();
        Assert.AreEqual("Yes", radioButton.GetWhichRadioSelected(), $"Expected, that Yes radio is selected");

    }

    [TestMethod]
    public void Buttons_ClickAllButtons()
    {
        Buttons buttons = new Buttons(driver);
        buttons.MainPageMenu.ClickOnBlock("Elements");
        buttons.LeftPanel.ClickOnSubMenu("Buttons");

        buttons.ClickDoubleClickMeButton();
        buttons.ClickRightClickMeButton();
        buttons.ClickClickMeButton();

        string clickMessage = buttons.GetClickMessage();
        string doubleClickMessage = buttons.GetDoubleClickMessage();
        string rightClickMessage = buttons.GetRightClickMessage();

        Assert.AreEqual("You have done a dynamic click", clickMessage, $"Expected message is: You have done a dynamic click");
        Assert.AreEqual("You have done a double click", doubleClickMessage, $"Expected message is: You have done a double click");
        Assert.AreEqual("You have done a right click", rightClickMessage, $"Expected message is: You have done a right click");

    }

    //TODO Tests
    [TestMethod]
    public void WebTables()
    {
        WebTables webTables = new WebTables(driver);
        webTables.MainPageMenu.ClickOnBlock("Elements");
        webTables.LeftPanel.ClickOnSubMenu("Web Tables");


        //webTables.GetTableValues();




    }
    [TestMethod]
    public void DynamicProperties()
    {

        DynamicProperties dProperties = new DynamicProperties(driver);
        dProperties.MainPageMenu.ClickOnBlock("Elements");
        dProperties.LeftPanel.ClickOnSubMenu("Dynamic Properties");

        bool isDisabled = dProperties.IsButtonDisabled("Will enable 5 seconds");
        string classAttribute = dProperties.GetColorChangeButtonClass();
        bool isVisible = dProperties.IsButtonVisible("Visible After 5 Seconds");

        Assert.IsFalse(isVisible, $"Button: Visible After 5 Seconds - expected to be invisible");
        Assert.IsTrue(isDisabled, $"Button: Will enable 5 seconds - expected to be disabled");
        Assert.AreEqual("mt-4 btn btn-primary", classAttribute, $"Button: Color Change - expected to have class: mt-4 btn btn-primary");

        Common.Wait(3);
        Assert.IsTrue(dProperties.IsButtonVisible("Visible After 5 Seconds"), $"Button: Visible After 5 Seconds - expected to be visible");
        Assert.IsFalse(dProperties.IsButtonDisabled("Will enable 5 seconds"), $"Button: Will enable 5 seconds - expected to be enabled");
        Assert.AreEqual("mt-4 text-danger btn btn-primary", dProperties.GetColorChangeButtonClass(), $"Button: Color Change - expected to have class: mt-4 text-danger btn btn-primary");


    }
    [TestMethod]
    public void UploadDownload()
    {

        UploadDownload uploadDownload = new UploadDownload(driver);
        uploadDownload.MainPageMenu.ClickOnBlock("Elements");
        uploadDownload.LeftPanel.ClickOnSubMenu("Upload and Download");

        uploadDownload.UploadTestFile();
        string uploadedFilePath = uploadDownload.GetUploadedFilePath();
        Assert.AreEqual("C:\\fakepath\\TestUpload.txt", uploadedFilePath, $"Expected path - C:\\fakepath\\TestUpload.txt");

        string sampleFile = "sampleFile.jpeg";
        string samplePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", sampleFile);
        Common.DeleteFile(samplePath);
        uploadDownload.ClickDownloadButton();
                
        Assert.IsTrue(Common.IsFileInFolder(samplePath, 3), $"File: {sampleFile}, expected to exist");
        Common.DeleteFile(samplePath);
    }
    //todo navigation menu testing
    [TestMethod]
    public void NavigationMenuTesting()
    {
        //webTables.GetTableValues();




    }
}