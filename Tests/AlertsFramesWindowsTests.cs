namespace SeleniumTests;

[TestClass]
public class AlertsFramesWindowsTests : TestBase
{
    [TestInitialize]

    public void AutoStartDriver()
    {
        StartDriver();
        OpenUrl();
    }

    [TestMethod]
    public void Alerts()
    {
        Alerts alerts = new Alerts(driver);
        alerts.MainPageMenu.ClickOnBlock("Alerts, Frame & Windows");
        alerts.LeftPanel.ClickOnSubMenu("Alerts");

        //STEP1: Testing simple Alert
        alerts.ClickForAlert();
        bool alertExists = alerts.IsAlertPresent();
        Assert.IsTrue(alertExists, $"Expected that Alert Exists");
        string alertText = alerts.GetAlertText();
        Assert.AreEqual("You clicked a button", alertText, $"Expected Alert to have text: You clicked a button");
        alerts.AcceptAlert();
        alertExists = alerts.IsAlertPresent();
        Assert.IsFalse(alertExists, $"Expected that Alert does not Exist");

        //STEP2: Testing Alert, which appears in five seconds
        alerts.ClickForAlertIn5Seconds();
        bool alert5Exists = alerts.IsAlertPresent();
        Assert.IsFalse(alert5Exists, $"Expected that Alert does not Exist");
        Common.Wait(5);
        alert5Exists = alerts.IsAlertPresent();
        Assert.IsTrue(alert5Exists, $"Expected that Alert Exists");
        string alert5Text = alerts.GetAlertText();
        Assert.AreEqual("This alert appeared after 5 seconds", alert5Text, $"Expected Alert after 5 Seconds to have text: This alert appeared after 5 seconds");
        alerts.AcceptAlert();
        alert5Exists = alerts.IsAlertPresent();
        Assert.IsFalse(alert5Exists, $"Expected that Alert does not Exist");

        //STEP3: Testing Confirm Box
        alerts.ClickForConfirmBox();
        string confirmText = alerts.GetAlertText();
        Assert.AreEqual("Do you confirm action?", confirmText, $"Expected Confirm Box to have text: Do you confirm action?");
        //Select OK
        alerts.AcceptAlert();
        bool confirmBoxExists = alerts.IsAlertPresent();
        Assert.IsFalse(confirmBoxExists, $"Expected that Alert does not Exist");
        string selectedValue = alerts.GetValueSelectedInConfirmBox();
        Assert.AreEqual("You selected Ok", selectedValue, $"Expected that value should be: You selected Ok");
        //Call Confirm box to select Cancel
        alerts.ClickForConfirmBox();
        alerts.DismissAlert();
        confirmBoxExists = alerts.IsAlertPresent();
        Assert.IsFalse(confirmBoxExists, $"Expected that Alert does not Exist");
        selectedValue = alerts.GetValueSelectedInConfirmBox();
        Assert.AreEqual("You selected Cancel", selectedValue, $"Expected that value should be: You selected Cancel");

        //STEP4: Testing Prompt Box
        alerts.ClickForPromptBox();
        string promptText = alerts.GetAlertText();
        Assert.AreEqual("Please enter your name", promptText, $"Expected Confirm Box to have text: Please enter your name");
        string inputText = $"my name {Common.GenerateRandom()}";
        alerts.InputTextIntoAllert(inputText);
        alerts.AcceptAlert();
        Assert.AreEqual($"You entered {inputText}", alerts.GetValueEnteredInPromtBox(), $"Expected value to be: You entered {inputText}");
    }

    [TestMethod]
    public void Frames()
    {
        Frames frames = new Frames(driver);
        frames.MainPageMenu.ClickOnBlock("Alerts, Frame & Windows");
        frames.LeftPanel.ClickOnSubMenu("Frames");

        //switching between frames, validating frame texts
        frames.SwitchToFrameOne();
        string frameOneText = frames.GetSampleHeadingInFrame();
        Assert.AreEqual("This is a sample page", frameOneText, $"Expected text in frame one: 'This is a sample page'");

        frames.SwitchToMainFrame();
        frames.SwitchToFrameTwo();
        string frameTwoText = frames.GetSampleHeadingInFrame();
        Assert.AreEqual("This is a sample page", frameTwoText, $"Expected text in frame two: 'This is a sample page'");
    }

    [TestMethod]
    public void NestedFrames()
    {
        NestedFrames nestedFrames = new NestedFrames(driver);
        nestedFrames.MainPageMenu.ClickOnBlock("Alerts, Frame & Windows");
        nestedFrames.LeftPanel.ClickOnSubMenu("Nested Frames");

        //swithc to parent frame, validate text
        nestedFrames.SwitchToParentFrame();
        string parentFrameText = nestedFrames.GetParentFrameText();
        Assert.AreEqual("Parent frame", parentFrameText, $"Expected text in frame one: 'Parent frame'");
        //switch to child frame, validate text
        nestedFrames.SwitchToChildFrame();
        string childFrameText = nestedFrames.GetChildFrameText();
        Assert.AreEqual("Child Iframe", childFrameText, $"Expected text in frame two: 'Child Iframe'");
    }

    [TestMethod]
    public void ModalDialogs()
    {
        ModalDialogs modalDialogs = new ModalDialogs(driver);
        modalDialogs.MainPageMenu.ClickOnBlock("Alerts, Frame & Windows");
        modalDialogs.LeftPanel.ClickOnSubMenu("Modal Dialogs");

        //STEP1: test Small Modal
        modalDialogs.ClickSmallModalButton();
        string modalTitle = modalDialogs.GetModalTitle();
        string modalBody = modalDialogs.GetSmallModalBody();
        modalDialogs.ClickCloseButton();
        Assert.AreEqual("Small Modal", modalTitle, $"Expected Modal title: Small Modal");
        Assert.IsTrue(modalBody.Contains("It has very less content"), $"Expected that modal body contains text: 'It has very less content'");

        //STEP2: test large Modal
        modalDialogs.ClickLargeModalButton();
        modalTitle = modalDialogs.GetModalTitle();
        modalBody = modalDialogs.GetLargeModalBody();
        modalDialogs.ClickXButton();
        Assert.AreEqual("Large Modal", modalTitle, $"Expected Modal title: Large Modal");
        Assert.IsTrue(modalBody.Contains("It has survived not only five centuries"), $"Expected that modal body contains text: 'It has survived not only five centuries'");
    }

    [TestMethod]
    public void BrowserWindows()
    {
        BrowserWindows browserWindows = new BrowserWindows(driver);
        browserWindows.MainPageMenu.ClickOnBlock("Alerts, Frame & Windows");
        browserWindows.LeftPanel.ClickOnSubMenu("Browser Windows");

        //STEP1: test New Tab Button
        browserWindows.ClickNewTabButton();
        browserWindows.SwitchToNewTab();
        string newPageText = browserWindows.GetNewPageText();
        browserWindows.ReturnToMainTab();
        StringAssert.Contains(newPageText, "This is a sample page");

        //STEP2: test New Window Button
        browserWindows.ClickNewWindowButton();
        browserWindows.SwitchToNewWindow();
        newPageText = browserWindows.GetNewPageText();
        browserWindows.ReturnToMainPage();
        StringAssert.Contains(newPageText, "This is a sample page");

        //STEP3: test New Winodow Message
        browserWindows.ClickNewWindowMessageButton();
        browserWindows.SwitchToNewWindow();
        newPageText = browserWindows.GetMessagePageText();
        browserWindows.ReturnToMainPage();
        StringAssert.Contains(newPageText, "Please share this website with your friends");        
    }
}