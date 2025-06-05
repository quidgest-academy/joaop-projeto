using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_agentForm : Form
{
	/// <summary>
	/// New Zone
	/// </summary>
	public IWebElement PseudNewgrp03 => throw new NotImplementedException();

	/// <summary>
	/// agent's info
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#F_AGENT_PSEUDNEWGRP01-container");

	/// <summary>
	/// Photo's Agent
	/// </summary>
	public BaseInputControl AgentPhoto => new BaseInputControl(driver, ContainerLocator, "container-F_AGENT_AGENTPHOTO___", "#F_AGENT_AGENTPHOTO___");

	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl AgentGender => new EnumControl(driver, ContainerLocator, "container-F_AGENT_AGENTGENDER__");

	/// <summary>
	/// Agent´s Name
	/// </summary>
	public BaseInputControl AgentName => new BaseInputControl(driver, ContainerLocator, "container-F_AGENT_AGENTNAME____", "#F_AGENT_AGENTNAME____");

	/// <summary>
	/// Agent's Email
	/// </summary>
	public BaseInputControl AgentEmail => new BaseInputControl(driver, ContainerLocator, "container-F_AGENT_AGENTEMAIL___", "#F_AGENT_AGENTEMAIL___");

	/// <summary>
	/// Agent's Phone
	/// </summary>
	public BaseInputControl AgentPhone => new BaseInputControl(driver, ContainerLocator, "container-F_AGENT_AGENTPHONE___", "#F_AGENT_AGENTPHONE___");

	/// <summary>
	/// comission Details
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#F_AGENT_PSEUDNEWGRP02-container");

	/// <summary>
	/// Percentage of the Comission
	/// </summary>
	public BaseInputControl AgentPerc_com => new BaseInputControl(driver, ContainerLocator, "container-F_AGENT_AGENTPERC_COM", "#F_AGENT_AGENTPERC_COM");

	/// <summary>
	/// Total earn through comission
	/// </summary>
	public BaseInputControl AgentTotcomis => new BaseInputControl(driver, ContainerLocator, "container-F_AGENT_AGENTTOTCOMIS", "#F_AGENT_AGENTTOTCOMIS");

	public F_agentForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_AGENT", containerLocator: containerLocator) { }
}
