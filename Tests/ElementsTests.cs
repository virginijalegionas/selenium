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
    public void TextBox()
    {
        TextBox textBox = new TextBox(driver);
        textBox.MainPageMenu.ClickOnBlock("Elements");
        textBox.LeftPanel.ClickOnSubMenu("Text Box");
        //STEP1: fill values
        //fill testing values
        string myName = $"name {Common.GenerateRandom()}";
        string myEmail = $"email@mail.com";
        string myCurrentAddress = $"currAddr {Common.GenerateRandom()}";
        string myPermanentAddress = $"perAddr {Common.GenerateRandom()}";
        textBox.InputFullName(myName);
        textBox.InputEmail(myEmail);
        textBox.InputCurrentAddress(myCurrentAddress);
        textBox.InputPermanentAddress(myPermanentAddress);
        textBox.ClickSubmit();
        //validate values
        Dictionary<string, string> outputValues = textBox.GetOutputValues();
        Assert.AreEqual(myName, outputValues["Name"], $"Expected Name value to be: {myName}");
        Assert.AreEqual(myEmail, outputValues["Email"], $"Expected Email value to be: {myEmail}");
        Assert.AreEqual(myCurrentAddress, outputValues["Current Address"], $"Expected Current Address value to be: {myCurrentAddress}");
        Assert.AreEqual(myPermanentAddress, outputValues["Permananet Address"], $"Expected Permanant Address value to be: {myPermanentAddress}");

        //STEP2: enter incorrect email
        textBox.InputEmail("wrongMail");
        textBox.ClickSubmit();
        Assert.IsTrue(textBox.IsEmailFieldMarkedRed(), $"Expected Email field border is red");

        //STEP3: enter correct email
        textBox.InputEmail(myEmail);
        textBox.ClickSubmit();
        Assert.IsFalse(textBox.IsEmailFieldMarkedRed(), $"Expected Email field border is NOT red");
    }

    [TestMethod]
    public void CheckBox()
    {
        CheckBox checkBox = new CheckBox(driver);
        checkBox.MainPageMenu.ClickOnBlock("Elements");
        checkBox.LeftPanel.ClickOnSubMenu("Check Box");

        //some exploratory test on expanding checking and unchecking nodes
        checkBox.ExpandTreeNode("Home");
        Assert.IsFalse(checkBox.IsTreeNodeExpanded("Desktop"), $"Desktop expected to be collapsed");

        checkBox.ExpandTreeNode("Desktop");
        Assert.IsTrue(checkBox.IsTreeNodeExpanded("Desktop"), $"Desktop expected to be expanded");
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Desktop"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Notes"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Commands"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Home"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Documents"));

        checkBox.CheckTreeNode("Notes");
        StringAssert.Equals("half checked", checkBox.GetNodeCheckedStatus("Desktop"));
        StringAssert.Equals("checked", checkBox.GetNodeCheckedStatus("Notes"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Commands"));
        StringAssert.Equals("half checked", checkBox.GetNodeCheckedStatus("Home"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Documents"));

        checkBox.CheckTreeNode("Commands");
        StringAssert.Equals("checked", checkBox.GetNodeCheckedStatus("Desktop"));
        StringAssert.Equals("checked", checkBox.GetNodeCheckedStatus("Notes"));
        StringAssert.Equals("checked", checkBox.GetNodeCheckedStatus("Commands"));
        StringAssert.Equals("half checked", checkBox.GetNodeCheckedStatus("Home"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Documents"));

        checkBox.UnCheckTreeNode("Desktop");
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Desktop"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Notes"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Commands"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Home"));
        StringAssert.Equals("unchecked", checkBox.GetNodeCheckedStatus("Documents"));

        checkBox.CollapseTreeNode("Home");
        Assert.IsFalse(checkBox.IsTreeNodeExpanded("Home"), $"Home expected to be collapsed");
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
    public void Buttons()
    {
        Buttons buttons = new Buttons(driver);
        buttons.MainPageMenu.ClickOnBlock("Elements");
        buttons.LeftPanel.ClickOnSubMenu("Buttons");

        //Clicking and validating all buttons
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
    public void WebTables()
    {
        WebTables webTables = new WebTables(driver);
        webTables.MainPageMenu.ClickOnBlock("Elements");
        webTables.LeftPanel.ClickOnSubMenu("Web Tables");

        //validating records we currently have in the table
        List<Dictionary<string, string>> webTableValues = webTables.GetTableValues();
        //Record for delete
        Assert.IsNotNull(webTableValues.SingleOrDefault(x => x["First Name"] == "Cierra"
                                        && x["Last Name"] == "Vega"
                                        && x["Email"] == "cierra@example.com"), $"Expected that Record: Cierra Verga cierra@example.com is in the Table");
        //Record for update
        Assert.IsNotNull(webTableValues.SingleOrDefault(x => x["First Name"] == "Alden"
                                        && x["Last Name"] == "Cantrell"
                                        && x["Age"] == "45"
                                        && x["Email"] == "alden@example.com"
                                        && x["Salary"] == "12000"
                                        && x["Department"] == "Compliance"), $"Expected that Record: Alden Cantrell alden@example.com is in the Table");

        //Delete Cierra record
        webTables.ClickDeleteByNameButton("Cierra");
        //Update Alden Record
        webTables.ClickEditByNameButton("Alden");
        webTables.InputFirstName("Alden_upd");
        webTables.InputLastName("Cantrell_upd");
        webTables.InputAge("55");
        webTables.InputEmail("alden_upd@example.com");
        webTables.InputSalary("13000");
        webTables.InputDepartment("Compliance_upd");
        webTables.ClickSubmitButton();

        //Add John record
        webTables.ClickAddButton();
        webTables.InputFirstName("John");
        webTables.InputLastName("Smith");
        webTables.InputAge("99");
        webTables.InputEmail("john_smith@example.com");
        webTables.InputSalary("55200");
        webTables.InputDepartment("CEO");
        webTables.ClickSubmitButton();

        //Validate values after delete, update and add
        webTableValues = webTables.GetTableValues();
        Assert.IsNull(webTableValues.SingleOrDefault(x => x["First Name"] == "Cierra"
                                        && x["Last Name"] == "Vega"
                                        && x["Email"] == "cierra@example.com"), $"Expected that Record: Cierra Verga cierra@example.com is NOT in the Table");
        Assert.IsNull(webTableValues.SingleOrDefault(x => x["First Name"] == "Alden"
                                        && x["Last Name"] == "Cantrell"
                                        && x["Age"] == "45"
                                        && x["Email"] == "alden@example.com"
                                        && x["Salary"] == "12000"
                                        && x["Department"] == "Compliance"), $"Expected that Record: Alden Cantrell alden@example.com is NOT in the Table");
        Assert.IsNotNull(webTableValues.SingleOrDefault(x => x["First Name"] == "Alden_upd"
                                        && x["Last Name"] == "Cantrell_upd"
                                        && x["Age"] == "55"
                                        && x["Email"] == "alden_upd@example.com"
                                        && x["Salary"] == "13000"
                                        && x["Department"] == "Compliance_upd"), $"Expected that Record: Alden_upd Cantrell_upd alden_upd@example.com is in the Table");
        Assert.IsNotNull(webTableValues.SingleOrDefault(x => x["First Name"] == "John"
                                        && x["Last Name"] == "Smith"
                                        && x["Age"] == "99"
                                        && x["Email"] == "john_smith@example.com"
                                        && x["Salary"] == "55200"
                                        && x["Department"] == "CEO"), $"Expected that Record: John Smith john_smith@example.com is in the Table");

    }

    [TestMethod]
    public void DynamicProperties()
    {
        DynamicProperties dProperties = new DynamicProperties(driver);
        dProperties.MainPageMenu.ClickOnBlock("Elements");
        dProperties.LeftPanel.ClickOnSubMenu("Dynamic Properties");

        //checking if buttons: are invisible, disabled and color is not changed at the begining
        bool isDisabled = dProperties.IsButtonDisabled("Will enable 5 seconds");
        string classAttribute = dProperties.GetColorChangeButtonClass();
        bool isVisible = dProperties.IsButtonVisible("Visible After 5 Seconds");

        Assert.IsFalse(isVisible, $"Button: Visible After 5 Seconds - expected to be invisible");
        Assert.IsTrue(isDisabled, $"Button: Will enable 5 seconds - expected to be disabled");
        Assert.AreEqual("mt-4 btn btn-primary", classAttribute, $"Button: Color Change - expected to have class: mt-4 btn btn-primary");

        //waiting and checking that buttons situations are changed
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

        //testing file upload
        uploadDownload.UploadFile("TestUpload.txt");
        string uploadedFilePath = uploadDownload.GetUploadedFilePath();
        Assert.AreEqual("C:\\fakepath\\TestUpload.txt", uploadedFilePath, $"Expected path - C:\\fakepath\\TestUpload.txt");

        //testing file download
        string sampleFile = "sampleFile.jpeg";
        string samplePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", sampleFile);
        Common.DeleteFile(samplePath);
        uploadDownload.ClickDownloadButton();

        Assert.IsTrue(Common.IsFileInFolder(samplePath, 3), $"File: {sampleFile}, expected to exist");
        Common.DeleteFile(samplePath);
    }

    [TestMethod]
    public void NavigationMenuTesting()
    {
        BaseOperations bOperations = new BaseOperations(driver);
        bOperations.MainPageMenu.ClickOnBlock("Elements");
        //some exploratory testing on left navigation menu
        Assert.IsFalse(bOperations.LeftPanel.IsLeftMenuExpanded("Forms"), $"Expected Forms menu to be collapsed");
        Assert.IsTrue(bOperations.LeftPanel.IsLeftMenuExpanded("Elements"), $"Expected Elements menu to be expanded");

        bOperations.LeftPanel.CollapseLeftMenu("Elements");
        bOperations.LeftPanel.ExpandLeftMenu("Forms");
        Common.Wait(2);
        Assert.IsFalse(bOperations.LeftPanel.IsLeftMenuExpanded("Elements"), $"Expected Elements menu to be collapsed");
        Assert.IsTrue(bOperations.LeftPanel.IsLeftMenuExpanded("Forms"), $"Expected Forms menu to be Expanded");

        bOperations.MainPageMenu.ClickHomePage();
        bOperations.MainPageMenu.ClickOnBlock("Widgets");
        Assert.IsTrue(bOperations.LeftPanel.IsLeftMenuExpanded("Widgets"), $"Expected Widgets menu to be Expanded");
        Assert.IsFalse(bOperations.LeftPanel.IsLeftMenuExpanded("Elements"), $"Expected Elements menu to be collapsed");

        bOperations.LeftPanel.CollapseLeftMenu("Widgets");
        bOperations.LeftPanel.ExpandLeftMenu("Forms");
        Common.Wait(2);
        Assert.IsFalse(bOperations.LeftPanel.IsLeftMenuExpanded("Widgets"), $"Expected Widgets menu to be collapsed");
        Assert.IsTrue(bOperations.LeftPanel.IsLeftMenuExpanded("Forms"), $"Expected Forms menu to be Expanded");
    }
}