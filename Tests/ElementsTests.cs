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
        Common.ClickBlockInMainMenu("Elements");
        Assert.IsTrue(Common.Validate.IsLeftMenuExpanded("Elements"), $"Expexted that Elements Menu on the left is expanded");
        Common.ClickOnSubMenu("Text Box");
        string myName = $"name {Common.GenerateRandom()}";
        string myEmail = $"email@mail.com";
        string myCurrentAddress = $"currAddr {Common.GenerateRandom()}";
        string myPermanentAddress = $"perAddr {Common.GenerateRandom()}";
        TextBox.InputFullName(myName);
        TextBox.InputEmail(myEmail);
        TextBox.InputCurrentAddress(myCurrentAddress);
        TextBox.InputPermanentAddress(myPermanentAddress);
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

        CheckBox.ExpandTreeNode("Home");
        CheckBox.ExpandTreeNode("Desktop");
        CheckBox.CheckTreeNode("Notes");
        CheckBox.CheckTreeNode("Documents");




    }
    [TestMethod]
    public void RadioButton()
    {
        Common.ClickBlockInMainMenu("Elements");
        Common.ClickOnSubMenu("Radio Button");

        Assert.IsFalse(RadioButtons.Validate.IsRadioDisabled("Yes"), $"Expected 'Yes' radio to be enabled ");
        Assert.IsTrue(RadioButtons.Validate.IsRadioDisabled("No"), $"Expected 'No' radio to be disabled");



    }

    [TestMethod]
    public void Buttons_ClickAllButtons()
    {
        Common.ClickBlockInMainMenu("Elements");
        Common.ClickOnSubMenu("Buttons");
        Buttons.ClickDoubleClickMeButton();
        Buttons.ClickRightClickMeButton();
        Buttons.ClickClickMeButton();

        string clickMessage = Buttons.Validate.GetClickMessage();
        string doubleClickMessage = Buttons.Validate.GetDoubleClickMessage();
        string rightClickMessage = Buttons.Validate.GetRightClickMessage();

        Assert.AreEqual("You have done a dynamic click", clickMessage, $"Expected message is: You have done a dynamic click");
        Assert.AreEqual("You have done a double click", doubleClickMessage, $"Expected message is: You have done a double click");
        Assert.AreEqual("You have done a right click", rightClickMessage, $"Expected message is: You have done a right click");

    }
    [TestMethod]
    public void xxxxx()
    {
        Common.ClickBlockInMainMenu("Elements");
        Common.ClickOnSubMenu("Web Tables");


        //WebTables.Validate.GetTableValues();




    }
}