using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_clubForm : Form
{
	/// <summary>
	/// Club's Name
	/// </summary>
	public BaseInputControl ClubName => new BaseInputControl(driver, ContainerLocator, "container-F_CLUB__CLUB_NAME____", "#F_CLUB__CLUB_NAME____");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-F_CLUB__CNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "F_CLUB", "F_CLUB__CNTRYCOUNTRY_");

	public F_clubForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_CLUB", containerLocator: containerLocator) { }
}
