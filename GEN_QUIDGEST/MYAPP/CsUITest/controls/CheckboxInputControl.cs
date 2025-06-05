namespace quidgest.uitests.controls;

public class CheckboxInputControl(IWebDriver driver, By containerLocator, string css) : ControlObject(driver, containerLocator, By.CssSelector(css))
{
    private IWebElement Checkbox => m_control.FindElement(By.CssSelector("[data-testid=checkbox-container]"));

    /// <summary>
    /// True if the control is blocked, false otherwise
    /// </summary>
    public bool IsBlocked => Checkbox.GetAttribute("class").Contains("disabled");

    public bool GetValue()
    {
        return Checkbox.FindElement(By.CssSelector("input")).Selected;
    }

    public void Toggle()
    {
        Checkbox.Click();
    }

    public void SetValue(bool val)
    {
        if (GetValue() != val)
            Toggle();
    }
}
