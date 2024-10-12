using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

public class Slider : BaseOperations
{
    public Slider(IWebDriver driver) : base(driver)
    {
    }

    public void SlideToPercentage(int percentage)
    {
        string sliderXpath = $"//input[@class='range-slider range-slider--primary']";
        IWebElement slider = GetElement(By.XPath(sliderXpath), 5);
        int width = slider.Size.Width;
        int target = width * percentage / 100 - width / 2;
        Actions action = new Actions(driver);
        action.DragAndDropToOffset(slider, target, 0)
        .Build()
        .Perform();
    }

    public string GetSliderValue()
    {
        return GetElement(By.Id("sliderValue"), 5).GetAttribute("value");
    }
}