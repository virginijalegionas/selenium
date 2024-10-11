using OpenQA.Selenium;

public class DatePicker : BaseOperations
{
    public DatePicker(IWebDriver driver) : base(driver)
    {
    }

    public string GetDateValue()
    {

        return GetElement(By.Id("datePickerMonthYearInput"), 5).GetAttribute("value");
    }

    public void SelectDateValue(DateOnly date)
    {

        SelectDateFromPicker(By.Id("datePickerMonthYearInput"), date);
    }

    public void SelectDateAndTime(DateTime dateTime)
    {
        GetElement(By.Id("dateAndTimePickerInput"), 5).Click();
        int thisYear = DateTime.Now.Year;
        if (thisYear != dateTime.Year)
        {
            SelectYear(dateTime.Year.ToString());
        }
        GetElement(By.ClassName("react-datepicker__month-read-view"), 5).Click();
        GetElement(By.XPath($"//div[text()='{dateTime.ToString("MMMM")}']"), 5).Click();

        string dayXpath = $"//div[@class='react-datepicker__week']//div[text()='{dateTime.Day}' and contains(@aria-label,'{dateTime.ToString("MMMM")}')]";
        GetElement(By.XPath(dayXpath), 5).Click();

        string timeXpath = $"//li[text()='{dateTime:HH}:{dateTime:mm}']";
        GetElement(By.XPath(timeXpath), 5).Click();

    }

    public void SelectYear(string year)
    {
        int thisYear = DateTime.Now.Year;
        GetElement(By.ClassName("react-datepicker__year-read-view"), 5).Click();
        IList<string> yearList = GetElements(By.ClassName("react-datepicker__year-option"), 5).Select(x => x.Text).ToList();
        while (!yearList.Contains(year) && int.Parse(year) != thisYear)
        {
            if (thisYear > int.Parse(year))
            {
                string previousYearXpath = $"//a[@class='react-datepicker__navigation react-datepicker__navigation--years react-datepicker__navigation--years-previous']//parent::div";
                GetElement(By.XPath(previousYearXpath), 5).Click();
            }
            else
            {
                string upcomingYearXpath = $"//a[@class='react-datepicker__navigation react-datepicker__navigation--years react-datepicker__navigation--years-upcoming']//parent::div";
                GetElement(By.XPath(upcomingYearXpath), 5).Click();
            }
            yearList = GetElements(By.ClassName("react-datepicker__year-option"), 5).Select(x => x.Text).ToList();
        }
        GetElement(By.XPath($"//div[@class='react-datepicker__year-option' and text()='{year}']"), 5).Click();
    }

    public string GetDateTimeValue()
    {
        return GetElement(By.Id("dateAndTimePickerInput"), 5).GetAttribute("value");
    }


}

