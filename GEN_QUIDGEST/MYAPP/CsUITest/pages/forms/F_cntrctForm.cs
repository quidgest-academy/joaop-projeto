using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_cntrctForm : Form
{
	/// <summary>
	/// Percentage of the Comission
	/// </summary>
	public IWebElement AgentPerc_com => throw new NotImplementedException();

	/// <summary>
	/// New Zone
	/// </summary>
	public IWebElement PseudNewgrp03 => throw new NotImplementedException();

	/// <summary>
	/// identification details
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#F_CNTRCTPSEUDNEWGRP01-container");

	/// <summary>
	/// Name of the player
	/// </summary>
	public LookupControl PlayrName => new LookupControl(driver, ContainerLocator, "container-F_CNTRCTPLAYRNAME____");
	public SeeMorePage PlayrNameSeeMorePage => new SeeMorePage(driver, "F_CNTRCT", "F_CNTRCTPLAYRNAME____");

	/// <summary>
	/// Club's Name
	/// </summary>
	public LookupControl ClubName => new LookupControl(driver, ContainerLocator, "container-F_CNTRCTCLUB_NAME____");
	public SeeMorePage ClubNameSeeMorePage => new SeeMorePage(driver, "F_CNTRCT", "F_CNTRCTCLUB_NAME____");

	/// <summary>
	/// Agent's Email
	/// </summary>
	public IWebElement AgentEmail => throw new NotImplementedException();

	/// <summary>
	/// contract details
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#F_CNTRCTPSEUDNEWGRP02-container");

	/// <summary>
	/// Starting Date
	/// </summary>
	public DateInputControl ContrStartdat => new DateInputControl(driver, ContainerLocator, "#F_CNTRCTCONTRSTARTDAT");

	/// <summary>
	/// Finish Date
	/// </summary>
	public DateInputControl ContrFindate => new DateInputControl(driver, ContainerLocator, "#F_CNTRCTCONTRFINDATE_");

	/// <summary>
	/// Contract duration
	/// </summary>
	public BaseInputControl ContrCtrdurat => new BaseInputControl(driver, ContainerLocator, "container-F_CNTRCTCONTRCTRDURAT", "#F_CNTRCTCONTRCTRDURAT");

	/// <summary>
	/// Salary of the player
	/// </summary>
	public BaseInputControl ContrSalary => new BaseInputControl(driver, ContainerLocator, "container-F_CNTRCTCONTRSALARY__", "#F_CNTRCTCONTRSALARY__");

	/// <summary>
	/// Yearly Salary
	/// </summary>
	public BaseInputControl ContrSlryyr => new BaseInputControl(driver, ContainerLocator, "container-F_CNTRCTCONTRSLRYYR__", "#F_CNTRCTCONTRSLRYYR__");

	/// <summary>
	/// Transfer Value
	/// </summary>
	public BaseInputControl ContrTransval => new BaseInputControl(driver, ContainerLocator, "container-F_CNTRCTCONTRTRANSVAL", "#F_CNTRCTCONTRTRANSVAL");

	/// <summary>
	/// Monetary Value comissions through each transfer
	/// </summary>
	public BaseInputControl ContrComiseur => new BaseInputControl(driver, ContainerLocator, "container-F_CNTRCTCONTRCOMISEUR", "#F_CNTRCTCONTRCOMISEUR");

	public F_cntrctForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_CNTRCT", containerLocator: containerLocator) { }
}
