using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.framework;
using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels.Contr;

public class AJF_Menu_6111_RowViewModel : Models.Contr
{
	#region Constructors

	public AJF_Menu_6111_RowViewModel(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	public AJF_Menu_6111_RowViewModel(UserContext userContext, CSGenioAcontr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext, val, isEmpty, fieldsToSerialize)
	{
		InitRowProperties();
	}

	#endregion

	#region Private methods

	private void InitRowProperties()
	{
		SetColumns();
		SetCustomActions();
	}

	private void SetColumns()
	{
		Columns ??= [
			new ListColumn()
			{
				Order = 1,
				Area = "CONTR",
				Field = "STARTDAT",
			},
			new ListColumn()
			{
				Order = 2,
				Area = "CONTR",
				Field = "COMISEUR",
			},
			new ListColumn()
			{
				Order = 3,
				Area = "CONTR",
				Field = "SALARY",
			},
			new ListColumn()
			{
				Order = 4,
				Area = "CONTR",
				Field = "FINDATE",
			},
			new ListColumn()
			{
				Order = 5,
				Area = "CONTR",
				Field = "CTRDURAT",
			},
			new ListColumn()
			{
				Order = 6,
				Area = "PLAYR",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 7,
				Area = "CONTR",
				Field = "TRANSVAL",
			},
			new ListColumn()
			{
				Order = 8,
				Area = "CLUB",
				Field = "NAME",
			},
			new ListColumn()
			{
				Order = 9,
				Area = "AGENT",
				Field = "EMAIL",
			},
		];
	}

	private void SetButtonPermissions()
	{
		if (BtnPermission != null)
			return;

		bool canView = true;
		bool canEdit = true;
		bool canDelete = true;
		bool canDuplicate = true;
		bool canInsert = true;

		using (new CSGenio.persistence.ScopedPersistentSupport(m_userContext.PersistentSupport))
		{
		}

		BtnPermission = new TableRowCrudButtonPermissions()
		{
			ViewBtnDisabled = !canView,
			EditBtnDisabled = !canEdit,
			DeleteBtnDisabled = !canDelete,
			DuplicateBtnDisabled = !canDuplicate,
			InsertBtnDisabled = !canInsert
		};
	}

	private void SetCustomActions()
	{
		CustomActions ??= new()
		{
		};
	}

	#endregion

	/// <summary>
	/// The state of the row (it's an internal value, therefore it shouldn't be sent to the client-side)
	/// </summary>
	[JsonIgnore]
	public override int ValZzstate => base.ValZzstate;

	/// <summary>
	/// Whether the row is in a valid state
	/// </summary>
	[JsonPropertyName("isValid")]
	public bool IsValid => ValZzstate == 0;

	/// <summary>
	/// The list columns
	/// </summary>
	[JsonPropertyName("columns")]
	public List<ListColumn> Columns { get; private set; }

	/// <summary>
	/// The button permissions
	/// </summary>
	[JsonPropertyName("btnPermission")]
	public TableRowCrudButtonPermissions BtnPermission { get; private set; }

	/// <summary>
	/// The custom action buttons
	/// </summary>
	[JsonPropertyName("customActions")]
	public Dictionary<string, ListCustomAction> CustomActions { get; private set; }

	/// <summary>
	/// The foreground color
	/// </summary>
	[JsonPropertyName("foregroundColor")]
	public string ForegroundColor => "";

	/// <summary>
	/// The background color
	/// Formula: iif ([CONTR->SALARY] < 50000, HEXCOLOUR ("Ff007f"), iif ([CONTR->SALARY] > 100000, HEXCOLOUR ("e8bcf0"), HEXCOLOUR ("ffffff")))
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	public string BackgroundColor => ((((decimal)this.ValSalary)<50000)?("#"+"Ff007f"):(((((decimal)this.ValSalary)>100000)?("#"+"e8bcf0"):("#"+"ffffff"))));

	/// <summary>
	/// Runs init logic that depends on row data.
	/// </summary>
	public void InitRowData()
	{
		SetButtonPermissions();
	}
}
