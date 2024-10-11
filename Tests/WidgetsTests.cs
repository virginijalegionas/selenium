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
        Assert.IsTrue(tabText.Contains("standard chunk of Lorem Ipsum used since the 1500s is reproduced"), $"Expected text contains: standard chunk of Lorem Ipsum used since the 1500s is reproduced");

        //Open Use Tab
        tabs.ClickOnTab("Use");
        tabText = tabs.GetTabText();
        Assert.IsTrue(tabText.Contains("English. Many desktop publishing packages"), $"Expected text contains: English. Many desktop publishing packages");
    }

    [TestMethod]
    public void SelectMenu()
    {
        SelectMenu selectMenu = new SelectMenu(driver);
        selectMenu.MainPageMenu.ClickOnBlock("Widgets");
        selectMenu.LeftPanel.ClickOnSubMenu("Select Menu");

        string selectValue = "Group 2, option 1";
        selectMenu.SelectValue(selectValue);
        Assert.AreEqual(selectValue, selectMenu.GetSelectedValue(), $"Expected select value: {selectValue}");

        string selectOneValue = "Prof.";
        selectMenu.SelectOneValue(selectOneValue);
        Assert.AreEqual(selectOneValue, selectMenu.GetSelectedOneValue(), $"Expected select value: {selectOneValue}");

        string selectOldStyleDropDownValue = "Magenta";
        selectMenu.SelectOldStyleDropDownValue(selectOldStyleDropDownValue);
        Assert.AreEqual(selectOldStyleDropDownValue, selectMenu.GetSelectedOldStyleDropDownValue(), $"Expected select value: {selectOldStyleDropDownValue}");

        IList<string> selectMultiValues = ["Green", "Red"];
        foreach (string value in selectMultiValues)
        {
            selectMenu.SelectMultiSelectDropDown(value);
        }
        IList<string> getMultiValues = selectMenu.GetSelectedMultiSelectDropDownValues();
        CollectionAssert.AreEquivalent(selectMultiValues.ToArray(), getMultiValues.ToArray());

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

        Assert.IsTrue(accordian.IsAccordianExpanded("What is Lorem Ipsum?"), $"Accordian - What is Lorem Ipsum? Expected to be Expanded");
        Assert.IsFalse(accordian.IsAccordianExpanded("Where does it come from?"), $"Accordian - Where does it come from? Expected to be Expanded");
        accordian.ExpandAccordian("Where does it come from?");
        string accordianText = accordian.GetExpandedAccordianText();
        Assert.IsTrue(accordianText.Contains("Malorum\" by Cicero are also reproduced"), $"Expected Accordian contain text: Malorum\" by Cicero are also reproduced");
        accordian.ExpandAccordian("Why do we use it?");
        accordianText = accordian.GetExpandedAccordianText();
        Assert.IsTrue(accordianText.Contains("English. Many desktop publishing"), $"Expected Accordian contain text: English. Many desktop publishing");
    }

    [TestMethod]
    public void DatePicker()
    {
        DatePicker datePicker = new DatePicker(driver);
        datePicker.MainPageMenu.ClickOnBlock("Widgets");
        datePicker.LeftPanel.ClickOnSubMenu("Date Picker");

        DateOnly dateValue = new DateOnly(2004, 06, 07);
        datePicker.SelectDateValue(dateValue);
        Assert.AreEqual(dateValue.ToString("MM/dd/yyyy"), datePicker.GetDateValue(), $"Expected Date of Date value to be: '06/07/2004'");

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

        slider.SlideToPercentage(30);
        string sliderValue = slider.GetSliderValue();
        CollectionAssert.Contains(new[] { 28, 29, 30, 31, 32 }, int.Parse(sliderValue));

        slider.SlideToPercentage(15);
        sliderValue = slider.GetSliderValue();
        CollectionAssert.Contains(new[] { 13, 14, 15, 16, 17 }, int.Parse(sliderValue));

        slider.SlideToPercentage(75);
        sliderValue = slider.GetSliderValue();
        CollectionAssert.Contains(new[] { 73, 74, 75, 76, 77 }, int.Parse(sliderValue));
    }


    [TestMethod]
    public void ToolTips()
    {
        ToolTips toolTips = new ToolTips(driver);
        toolTips.MainPageMenu.ClickOnBlock("Widgets");
        toolTips.LeftPanel.ClickOnSubMenu("Tool Tips");

        string buttonToolTip = toolTips.GetButtonToolTip();
        Assert.AreEqual("You hovered over the Button", buttonToolTip);

        string textFieldToolTip = toolTips.GetTextFieldToolTip();
        Assert.AreEqual("You hovered over the text field", textFieldToolTip);
    }

    [TestMethod]
    public void ProgressBar()
    {
        ProgressBar progressBar = new ProgressBar(driver);
        progressBar.MainPageMenu.ClickOnBlock("Widgets");
        progressBar.LeftPanel.ClickOnSubMenu("Progress Bar");

        progressBar.ClickStartStopButton();
        Common.Wait(3);
        progressBar.ClickStartStopButton();
        string progressValue = progressBar.GetProgressBarValue();
        CollectionAssert.Contains(new[] { 30, 31, 32, 33, 34 }, int.Parse(progressValue));
        Console.WriteLine($"progress value: {progressValue}");

        progressBar.ClickStartStopButton();
        Common.Wait(3);
        progressBar.ClickStartStopButton();
        progressValue = progressBar.GetProgressBarValue();
        CollectionAssert.Contains(new[] { 60, 61, 62, 63, 64, 65 }, int.Parse(progressValue));
        Console.WriteLine($"progress value: {progressValue}");

    }

}