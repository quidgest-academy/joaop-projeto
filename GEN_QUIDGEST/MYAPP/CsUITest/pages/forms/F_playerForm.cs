﻿using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class F_playerForm : Form
{
	/// <summary>
	/// Under Contract?
	/// </summary>
	public EnumControl PlayrUndctc => new EnumControl(driver, ContainerLocator, "container-F_PLAYERPLAYRUNDCTC__");

	/// <summary>
	/// Player Details
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#F_PLAYERPSEUDNEWGRP01-container");

	/// <summary>
	/// Gender
	/// </summary>
	public EnumControl PlayrGender => new EnumControl(driver, ContainerLocator, "container-F_PLAYERPLAYRGENDER__");

	/// <summary>
	/// Name of the player
	/// </summary>
	public BaseInputControl PlayrName => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYERPLAYRNAME____", "#F_PLAYERPLAYRNAME____");

	/// <summary>
	/// Birthdate
	/// </summary>
	public DateInputControl PlayrBirthdat => new DateInputControl(driver, ContainerLocator, "#F_PLAYERPLAYRBIRTHDAT");

	/// <summary>
	/// Player's Age
	/// </summary>
	public BaseInputControl PlayrAge => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYERPLAYRAGE_____", "#F_PLAYERPLAYRAGE_____");

	/// <summary>
	/// Country
	/// </summary>
	public LookupControl CntryCountry => new LookupControl(driver, ContainerLocator, "container-F_PLAYERCNTRYCOUNTRY_");
	public SeeMorePage CntryCountrySeeMorePage => new SeeMorePage(driver, "F_PLAYER", "F_PLAYERCNTRYCOUNTRY_");

	/// <summary>
	/// Position
	/// </summary>
	public BaseInputControl PlayrPosic => new BaseInputControl(driver, ContainerLocator, "container-F_PLAYERPLAYRPOSIC___", "#F_PLAYERPLAYRPOSIC___");

	/// <summary>
	/// Agent´s Name
	/// </summary>
	public LookupControl AgentName => new LookupControl(driver, ContainerLocator, "container-F_PLAYERAGENTNAME____");
	public SeeMorePage AgentNameSeeMorePage => new SeeMorePage(driver, "F_PLAYER", "F_PLAYERAGENTNAME____");

	public F_playerForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "F_PLAYER", containerLocator: containerLocator) { }
}
