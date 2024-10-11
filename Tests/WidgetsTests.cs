namespace SeleniumTests;

[TestClass]
public class WidgetsTests : TestBase
{
    [TestInitialize]

    public void AutoStartDriver()
    {
        StartDriver();
        OpenUrl();
    }

    [TestMethod]
    public void Tabs()
    {
        Tabs tabs = new Tabs(driver);
        tabs.MainPageMenu.ClickOnBlock("Widgets");
        tabs.LeftPanel.ClickOnSubMenu("Tabs");

        //Open Origin Tab
        tabs.ClickOnTab("Origin");
        string tabText = tabs.GetTabText();
        StringAssert.Contains(tabText, "standard chunk of Lorem Ipsum used since the 1500s is reproduced");

        //Open Use Tab
        tabs.ClickOnTab("Use");
        tabText = tabs.GetTabText();
        StringAssert.Contains(tabText, "English. Many desktop publishing packages");        
    }

    [TestMethod]
    public void SelectMenu()
    {
        SelectMenu selectMenu = new SelectMenu(driver);
        selectMenu.MainPageMenu.ClickOnBlock("Widgets");
        selectMenu.LeftPanel.ClickOnSubMenu("Select Menu");

        //STEP1: selecting value from first select menu
        string selectValue = "Group 2, option 1";
        selectMenu.SelectValue(selectValue);
        Assert.AreEqual(selectValue, selectMenu.GetSelectedValue(), $"Expected select value: {selectValue}");

        //STEP2: selecting value from second select menu
        string selectOneValue = "Prof.";
        selectMenu.SelectOneValue(selectOneValue);
        Assert.AreEqual(selectOneValue, selectMenu.GetSelectedOneValue(), $"Expected select value: {selectOneValue}");

        //STEP3: selecting value from old style select menu
        string selectOldStyleDropDownValue = "Magenta";
        selectMenu.SelectOldStyleDropDownValue(selectOldStyleDropDownValue);
        Assert.AreEqual(selectOldStyleDropDownValue, selectMenu.GetSelectedOldStyleDropDownValue(), $"Expected select value: {selectOldStyleDropDownValue}");

        //STEP4: selecting value from multi value select menu
        IList<string> selectMultiValues = ["Green", "Red"];
        foreach (string value in selectMultiValues)
        {
            selectMenu.SelectMultiSelectDropDown(value);
        }
        IList<string> getMultiValues = selectMenu.GetSelectedMultiSelectDropDownValues();
        CollectionAssert.AreEquivalent(selectMultiValues.ToArray(), getMultiValues.ToArray());

        //STEP5: selecting value from standard multi value select menu
        IList<string> selectStandardMultiValues = ["Saab", "Opel"];
        foreach (string value in selectStandardMultiValues)
        {
            selectMenu.SelectStandardMultiSelectValue(value);
        }
        IList<string> getStandardMultiValues = selectMenu.GetSelectedStandardMultiSelectValues();
        CollectionAssert.AreEquivalent(selectStandardMultiValues.ToArray(), getStandardMultiValues.ToArray());
    }

    [TestMethod]
    public void Accordian()
    {
        Accordian accordian = new Accordian(driver);
        accordian.MainPageMenu.ClickOnBlock("Widgets");
        accordian.LeftPanel.ClickOnSubMenu("Accordian");

        //by default first accordian is already expanded
        Assert.IsTrue(accordian.IsAccordianExpanded("What is Lorem Ipsum?"), $"Accordian - What is Lorem Ipsum? Expected to be Expanded");
        Assert.IsFalse(accordian.IsAccordianExpanded("Where does it come from?"), $"Accordian - Where does it come from? Expected to be not Expanded");
        //expanding next accordian
        accordian.ExpandAccordian("Where does it come from?");
        //prevously expanded Accordian is collapsed
        Assert.IsFalse(accordian.IsAccordianExpanded("What is Lorem Ipsum?"), $"Accordian - What is Lorem Ipsum? Expected to not Expanded");
        string accordianText = accordian.GetExpandedAccordianText();
        StringAssert.Contains(accordianText, "Malorum\" by Cicero are also reproduced");
        //validating one more Accordian
        accordian.ExpandAccordian("Why do we use it?");
        accordianText = accordian.GetExpandedAccordianText();
        StringAssert.Contains(accordianText, "English. Many desktop publishing");
    }

    [TestMethod]
    public void DatePicker()
    {
        DatePicker datePicker = new DatePicker(driver);
        datePicker.MainPageMenu.ClickOnBlock("Widgets");
        datePicker.LeftPanel.ClickOnSubMenu("Date Picker");

        //Testing only date picker
        DateOnly dateValue = new DateOnly(2004, 06, 07);
        datePicker.SelectDateValue(dateValue);
        Assert.AreEqual(dateValue.ToString("MM/dd/yyyy"), datePicker.GetDateValue(), $"Expected Date of Date value to be: '06/07/2004'");

        //Testing time and date picker
        DateTime dateTime = new DateTime(2011, 04, 27, 03, 15, 00);
        datePicker.SelectDateAndTime(dateTime);
        Assert.AreEqual(dateTime.ToString("MMMM d, yyyy H:mm tt"), datePicker.GetDateTimeValue(), $"Expected Date Time value to be: 'June 9, 2011 03:15'");
    }

    [TestMethod]
    public void Slider()
    {
        Slider slider = new Slider(driver);
        slider.MainPageMenu.ClickOnBlock("Widgets");
        slider.LeftPanel.ClickOnSubMenu("Slider");

        //test few slides
        slider.SlideToPercentage(30);
        string sliderValue = slider.GetSliderValue();
        Assert.AreEqual(30, int.Parse(sliderValue), 2);

        slider.SlideToPercentage(15);
        sliderValue = slider.GetSliderValue();
        Assert.AreEqual(15, int.Parse(sliderValue), 2);

        slider.SlideToPercentage(75);
        sliderValue = slider.GetSliderValue();
        Assert.AreEqual(75, int.Parse(sliderValue), 2);
    }

    [TestMethod]
    public void ToolTips()
    {
        ToolTips toolTips = new ToolTips(driver);
        toolTips.MainPageMenu.ClickOnBlock("Widgets");
        toolTips.LeftPanel.ClickOnSubMenu("Tool Tips");

        //Validating Button Tooltip
        string buttonToolTip = toolTips.GetButtonToolTip();
        Assert.AreEqual("You hovered over the Button", buttonToolTip);

        //Validating text field Tooltip
        string textFieldToolTip = toolTips.GetTextFieldToolTip();
        Assert.AreEqual("You hovered over the text field", textFieldToolTip);
    }

    [TestMethod]
    public void ProgressBar()
    {
        ProgressBar progressBar = new ProgressBar(driver);
        progressBar.MainPageMenu.ClickOnBlock("Widgets");
        progressBar.LeftPanel.ClickOnSubMenu("Progress Bar");

        //Test progress bar one time
        progressBar.ClickStartStopButton();
        Common.Wait(3);
        progressBar.ClickStartStopButton();
        string progressValue = progressBar.GetProgressBarValue();
        Assert.AreEqual(30, int.Parse(progressValue), 4);

        //Tests progress bar another time
        progressBar.ClickStartStopButton();
        Common.Wait(3);
        progressBar.ClickStartStopButton();
        progressValue = progressBar.GetProgressBarValue();
        Assert.AreEqual(60, int.Parse(progressValue), 4);
    }
}