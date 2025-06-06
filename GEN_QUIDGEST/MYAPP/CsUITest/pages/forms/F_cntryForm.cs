using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_cntryForm : PopupForm
{
	/// <summary>
	/// Country
	/// </summary>
	public BaseInputControl CntryCountry => new BaseInputControl(driver, ContainerLocator, "container-F_CNTRY_CNTRYCOUNTRY_", "#F_CNTRY_CNTRYCOUNTRY_");

	public F_cntryForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_CNTRY") { }
}
