using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class SelectMenu : BaseOperations
{
    public SelectMenu(IWebDriver driver) : base(driver)
    {
    }

    public void SelectValue(string selectValue)
    {
        string dropElementXpath = "//div[@id='withOptGroup']";
        GetElement(By.XPath(dropElementXpath), 5).Click();
        string dropDownXpath = $"//div[contains(text(),'{selectValue}')]";
        GetElement(By.XPath(dropDownXpath), 5).Click();
    }

    public string GetSelectedValue()
    {
        string xpath = "//div[text()='Select Value']//parent::div//following-sibling::div[1]//div[@class=' css-1uccc91-singleValue']";
        return GetElement(By.XPath(xpath), 5).Text;
    }

    public void SelectOneValue(string selectOneValue)
    {
        string dropElementXpath = "//div[@id='selectOne']";
        GetElement(By.XPath(dropElementXpath), 5).Click();
        string dropDownXpath = $"//div[contains(text(),'{selectOneValue}')]";
        GetElement(By.XPath(dropDownXpath), 5).Click();
    }

    public string GetSelectedOneValue()
    {
        string xpath = "//div[text()='Select One']//parent::div//following-sibling::div[1]//div[@class=' css-1uccc91-singleValue']";
        return GetElement(By.XPath(xpath), 5).Text;
    }

    public void SelectOldStyleDropDownValue(string oldStyleValue)
    {
        SelectElement oldDropDown = new SelectElement(driver.FindElement(By.Id("oldSelectMenu")));
        oldDropDown.SelectByText(oldStyleValue);
    }

    public string GetSelectedOldStyleDropDownValue()
    {
        SelectElement oldDropDown = new SelectElement(driver.FindElement(By.Id("oldSelectMenu")));
        return oldDropDown.SelectedOption.Text;
    }

    public void SelectMultiSelectDropDown(string multiSelectValue)
    {
        string xpath = $"//div/p/b[contains(text(), 'Multiselect drop down')]/parent::p/parent::div//div[@class = 'css-1g6gooi']//input";
        string searchString = multiSelectValue[..2];
        InputTextField(By.XPath(xpath), searchString);
        string dropDownXpath = $"//div[contains(text(),'{multiSelectValue}')]";
        GetElement(By.XPath(dropDownXpath), 5).Click();
    }

    public IList<string> GetSelectedMultiSelectDropDownValues()
    {
        string xpath = "//div[@class='css-12jo7m5']";
        IList<string> multiDropDownValues = GetElements(By.XPath(xpath), 5).Select(x => x.Text).ToList();
        return multiDropDownValues;
    }

    public void SelectStandardMultiSelectValue(string standardMultiSelectValue)
    {
        SelectElement oldDropDown = new SelectElement(driver.FindElement(By.Id("cars")));
        oldDropDown.SelectByText(standardMultiSelectValue);
    }

    public IList<string> GetSelectedStandardMultiSelectValues()
    {
        SelectElement standardMultiSelect = new SelectElement(driver.FindElement(By.Id("cars")));
        IList<string> selectedValues = standardMultiSelect.AllSelectedOptions.Select(x => x.Text).ToList();
        return selectedValues;
    }
}