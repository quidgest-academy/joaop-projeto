namespace quidgest.uitests.pages;

public class ConfirmationPopup: PageObject
{
    // TODO: When the "SweetAlert" dependency is removed, this should be improved so it doesn't use class names.
    IWebElement dialogContainer => driver.FindElement(By.CssSelector(".swal2-container.swal2-backdrop-show"));
    IWebElement dialog => driver.FindElement(By.CssSelector(".swal2-popup[role='dialog']"));
    IWebElement buttonOk => dialog.FindElement(By.CssSelector("button.swal2-confirm"));
    IWebElement buttonCancel => dialog.FindElement(By.CssSelector("button.swal2-cancel"));
    IWebElement buttonDeny => dialog.FindElement(By.CssSelector("button.swal2-deny"));
    IWebElement dialogText => dialog.FindElement(By.Id("swal2-html-container"));
    //This is the only property SweetAlert is setting when the animation finishes.
    bool dialogAnimationEnded => dialogContainer.GetAttribute("style").Contains("overflow-y: auto;");

    public ConfirmationPopup(IWebDriver driver): base(driver)
    {
		wait.Until(c => dialog);
        wait.Until(c => dialog.Displayed);
        wait.Until(c => dialogAnimationEnded);
	}

    public void Confirm()
    {
        buttonOk.AnimatedClick();
    }

    public void Cancel()
    {
        buttonCancel.AnimatedClick();
    }

    public void Deny()
    {
        buttonDeny.AnimatedClick();
    }

    public string GetDialogText()
    {
        return dialogText.Text;
    }
}
