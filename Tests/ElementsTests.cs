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
        Assert.IsTrue(textBox.LeftPanel.IsLeftMenuExpanded("Elements"), $"Expexted that Elements Menu on the left is expanded");



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
    [TestMethod]
    public void xxxxx()
    {
        WebTables webTables = new WebTables(driver);
        webTables.MainPageMenu.ClickOnBlock("Elements");
        webTables.LeftPanel.ClickOnSubMenu("Web Tables");


        //webTables.GetTableValues();




    }
}