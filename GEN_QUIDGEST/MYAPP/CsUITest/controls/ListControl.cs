using quidgest.uitests.pages.common;
using System.Collections.Generic;
using System.Linq;

namespace quidgest.uitests.controls;

public class ListControl : ControlObject
{
    /// <summary>
    /// Table ID
    /// </summary>
    private string id => m_control.GetAttribute("id");

    /// <summary>
    /// Row elements
    /// </summary>
    private IList<IWebElement> rows => m_control.FindElements(By.CssSelector("tbody tr:not(.c-table__row--empty)"));

    /// <summary>
    /// Column elements
    /// </summary>
	private IList<IWebElement> columns => m_control.FindElements(By.CssSelector("thead th"));

    /// <summary>
    /// Ordering column name
    /// </summary>
    private string orderingColumnName => m_control.FindElement(By.CssSelector(".thead-order"))?.GetAttribute("data-column-name");

    /// <summary>
    /// Ad advanced filter button
    /// </summary>
    private IWebElement addAdvancedFilterBtn => GetElement(m_control, By.CssSelector("[data-action-key='add-advanced-filter']"));

    //TODO - Instead of using title to identify the insert button we should create a specific attribute (Ex: data-key) for testing purpose
    /// <summary>
    /// Insert button
    /// </summary>
    private IWebElement insertBtn => m_control.FindElement(By.CssSelector("[data-testid=table-action][data-action-key='insert']"));

    /// <summary>
    /// Loading state
    /// </summary>
    private bool loading => m_control.FindElements(By.CssSelector("tbody.c-table__body--loading")).Any();

    /// <summary>
    /// Search bar
    /// </summary>
    public SearchControl Search => new SearchControl(driver, m_containerLocator, m_controlLocator);

    /// <summary>
    /// Table configuration menu button and items
    /// </summary>
    private IWebElement configBtn => GetElement(m_control, By.CssSelector("button[id$='config-menu-btn']"));

    /// <summary>
    /// Column config button
    /// </summary>
    private IWebElement columnConfigBtn => GetElement(m_control, By.CssSelector("button[id$='config-menu-btn-column-config']"));

	/// <summary>
	/// Table row reorder mode toggle button
	/// </summary>
	private IWebElement rowReorderBtn => GetElement(m_control, By.CssSelector("button[id$='row-reorder-btn']"));

    /// <summary>
    /// Total record counter
    /// </summary>
    private IWebElement recordCounter => GetElement(m_control, By.CssSelector(".e-counter__text"));

    /// <summary>
    /// Gets a value indicating whether the user can insert in this table.
    /// </summary>
    public bool CanInsert => insertBtn.Enabled;

    /// <summary>
	/// Row count
	/// </summary>
    public int RowCount
    {
        get
        {
            WaitForLoading();
            return rows.Count;
        }
    }

    public int TotalRecordCount
    {
        get
        {
            WaitForLoading();
            if (recordCounter == null)
                throw new InvalidOperationException($"List {id} does not have a record counter.");

            return int.Parse(recordCounter.Text);
        }
    }

    public ListControl(IWebDriver driver, By containerLocator, string css) :
        base(driver, containerLocator, By.CssSelector(css))
    {
        WaitForLoading();
    }

    /// <summary>
    /// Wait for page to load
    /// </summary>
    private void WaitForLoading()
    {
        wait.Until(c => !loading);
        wait.Message = $"Could not load list {id}";
        wait.Until(c => m_control.Displayed);
        wait.Message = $"The list {id} is not visible";
    }

    /// <summary>
    /// Get a row element from it's primary key
    /// </summary>
    /// <param name="pk">Row's primary key</param>
    /// <returns>Row element</returns>
    public int GetRowByPk(string pk)
    {
        WaitForLoading();
        return rows.FindIndex(r => r.GetAttribute("data-key") == pk);
    }

    /// <summary>
    /// Get a column's index from it's name
    /// </summary>
    /// <param name="fieldRef">Column's name</param>
    /// <returns>Column index</returns>
    private int GetRawColumnIndex(string fieldRef)
    {
        WaitForLoading();

        string column_locator;

        var parts = fieldRef.Split('.', 2);

        // If the field is given as an exact name, but not as TABLE.COLUMN
        if (parts.Length == 1)
            column_locator = fieldRef;
        // If the field is given as TABLE.COLUMN
        else
            column_locator = CapFirst(parts[0]) + ".Val" + CapFirst(parts[1]);

        return columns.FindIndex(h => h.GetAttribute("data-column-name") == column_locator);
    }

    /// <summary>
    /// Get a column's header element from it's name
    /// </summary>
    /// <param name="fieldRef">Column's name</param>
    /// <returns>Column element</returns>
    private IWebElement GetColumnHeader(string fieldRef)
    {
        int index = GetRawColumnIndex(fieldRef);

        // Bounds checking
        if (index < 0 || index >= columns.Count)
            return null;

        return columns[index];
    }

    /// <summary>
    /// Get a column's name from it's index
    /// </summary>
    /// <param name="index">Column's index</param>
    /// <returns>Column name</returns>
    private string GetRawColumnNameByIndex(int index)
    {
        WaitForLoading();

        // Bounds checking
        if (index < 0 || index >= columns.Count)
            return null;

        return columns[index].GetAttribute("data-column-name");
    }

    /// <summary>
    /// Get the number of non-data columns at the beginning of the column array
    /// </summary>
    /// <returns>Number of non-data columns</returns>
    private int NonDataColumnAtBeginningCount()
    {
        WaitForLoading();

        // Find the first column that is not one of the special types of columns
        int firstNonDataColumnIndex = columns.FindIndex(col =>
        {
            string columnName = col.GetAttribute("data-column-name");
            return !(columnName.Equals("actions") || columnName.Equals("Checkbox") || columnName.Equals("ExtendedAction") || columnName.Equals("dragAndDrop"));
        });

        // If all columns are special columns
        if (firstNonDataColumnIndex == -1)
            return columns.Count;

        // Index of first data column is the number of non-data columns
        return firstNonDataColumnIndex;
    }

    /// <summary>
    /// Get a column's index from it's name, relative to the starting index of data columns
    /// </summary>
    /// <param name="fieldRef">Column's name</param>
    /// <returns>Column index</returns>
    public int GetColumnIndex(string fieldRef)
    {
        WaitForLoading();

        // Get actual column index
        int columnIndex = GetRawColumnIndex(fieldRef);

        // Column not found
        if (columnIndex == -1)
            return -1;

        // Return index starting from where the data columns start
        return columnIndex - NonDataColumnAtBeginningCount();
    }

    /// <summary>
    /// Get a column's name from it's index, relative to the starting index of data columns
    /// </summary>
    /// <param name="index">Column's index</param>
    /// <returns>Column name</returns>
    public string GetColumnNameByIndex(int index)
    {
        WaitForLoading();

        // Add number of non data columns to index to use the actual index when finding the column
        return GetRawColumnNameByIndex(index + NonDataColumnAtBeginningCount());
    }

    /// <summary>
    /// Capitalize the first letter of a string
    /// </summary>
    /// <param name="s">string</param>
    /// <returns>string with the first letter capitalized</returns>
    private string CapFirst(string s)
    {
        if (s.Length == 0) return s;
        if (s.Length == 1) return s.ToUpperInvariant();
        return s.Substring(0, 1).ToUpperInvariant() + s.Substring(1).ToLowerInvariant();
    }

    /// <summary>
    /// Get a cell's value from it's row index and column name
    /// </summary>
    /// <param name="row">Row index</param>
    /// <param name="fieldRef">Column name</param>
    /// <returns>Cell value</returns>
    public string GetValue(int row, string fieldRef)
    {
        WaitForLoading();
        if (row < 0 || (row + 1) > RowCount) return null;

        int cix = GetRawColumnIndex(fieldRef);

        var cell = rows[row].FindElements(By.TagName("td"))[cix];
        return cell.Text;
    }

    /// <summary>
    /// Click on a row
    /// </summary>
    public void ClickRow(int index)
    {
        WaitForLoading();
        if (index >= rows.Count)
            throw new ArgumentException($"Invalid row index: {index}");

        rows[index].Click();
    }

    /// <summary>
    /// Click on the insert button
    /// </summary>
    public void Insert()
    {
        insertBtn.Click();
    }

    /// <summary>
    /// Run a row's action from it's row index and action name
    /// </summary>
    /// <param name="index">Row index</param>
    /// <param name="action">Action name</param>
    /// <param name="orderIndex">Index to move row to (only used with row reordering)</param>
    public void ExecuteAction(int index, String action, int orderIndex = 0)
    {
        WaitForLoading();
        if (index >= rows.Count || index < 0)
            throw new ArgumentException($"Invalid row index: {index}");

        var row = rows[index];

        // For row reorder functions, call specific functions
        if (action.Equals(ReorderAction.Reorder))
            ReorderRow(index, orderIndex);
        else if (action.Equals(ReorderAction.ReorderUp))
            ReorderRowUpOrDown(index, false);
        else if (action.Equals(ReorderAction.ReorderDown))
            ReorderRowUpOrDown(index, true);
        // Normal actions
        else
        {
            var cell = row.FindElement(By.CssSelector("td.row-actions"));

            //if it's a dropdown menu, click the button to open the dropdown. If the dropdown doesn't exist, the buttons are inlined.
            var dropdownButton = cell.FindElements(By.CssSelector("[data-type=options-button]"));
            if (dropdownButton.Count() > 0)
                dropdownButton[0].Click();

            var actionButton = driver.FindElement(By.CssSelector("[role=listbox] [role=option][data-key='" + action + "']"));

            actionButton.Click();
        }
    }

	private void OpenDropdown(int rowIndex)
	{
		if (rowIndex < 0 || rowIndex >= rows.Count)
			throw new ArgumentException($"Invalid row index: {rowIndex}");

		IWebElement row = rows[rowIndex];
		IWebElement cell = row.FindElement(By.CssSelector("td.row-actions"));

		// Close any dropdown that may already be open.
		var dropdownUnderlay = driver.FindElements(By.CssSelector(".q-overlay__underlay"));
		if (dropdownUnderlay.Count() > 0)
			dropdownUnderlay[0].Click();

		// If it's a dropdown menu, click the button to open the dropdown. If the dropdown doesn't exist, the buttons are inlined.
		var dropdownButton = cell.FindElements(By.CssSelector("[data-type=options-button]"));
		if (dropdownButton.Count() > 0)
			dropdownButton[0].Click();
	}

    /// <summary>
    /// Checks if a row's action exists from it's row index and action name
    /// </summary>
    /// <param name="index">Row index</param>
    /// <param name="action">Action name</param>
    public bool IsActionAvailable(int index, string action)
    {
        WaitForLoading();

        OpenDropdown(index);
        var actionButton = driver.FindElements(By.CssSelector("[role=listbox] [role=option][data-key='" + action + "']"));

        return actionButton.Count != 0;
    }

	/// <summary>
	/// Gets the number of actions that exist for the specified row
	/// </summary>
	/// <param name="rowIndex">The index of the row</param>
	/// <returns>The number of available actions</returns>
	/// <exception cref="ArgumentException"></exception>
	public int GetActionCount(int rowIndex)
	{
		WaitForLoading();

		OpenDropdown(rowIndex);
		var actionButtons = driver.FindElement(By.CssSelector("[data-testid='dropdown-content']")).FindElements(By.CssSelector("[role=listbox] [role=option]"));

		return actionButtons.Count;
	}

    /// <summary>
    /// Move the row at the given index to a new index
    /// </summary>
    /// <param name="currentIndex">Index of the row</param>
    /// <param name="newIndex">Index to move the row to</param>
    private void ReorderRow(int currentIndex, int newIndex)
    {
        // The element index starts at 0, it's always 1 less than the column order value
        int newOrderValue = newIndex + 1;

        // Get the input for the column order field and change it's value
        string inputId = $"{id}_{currentIndex}_{orderingColumnName}";
        BaseInputControl rowOrderInput = new BaseInputControl(driver, By.Id($"container-{inputId}"), $"container-{inputId}", $"#{inputId}");
        rowOrderInput.SetValue(newOrderValue.ToString());

        // Confirm the value
        rowOrderInput.Confirm();
    }

    /// <summary>
    /// Move the row at the given index up or down one
    /// </summary>
    /// <param name="currentIndex">Index of the row</param>
    /// <param name="incrememnt">Whether to move the row up or down one</param>
    private void ReorderRowUpOrDown(int currentIndex, bool incrememnt)
    {
        string direction = incrememnt ? "down" : "up";

        ButtonControl reorderUpDownBtn = new ButtonControl(driver, By.Id(id + "_row-" + currentIndex), "#" + id + "_row-" + currentIndex + "-reorder-" + direction);

        reorderUpDownBtn.Click();
    }

    /// <summary>
    /// Sort a table by a column
    /// </summary>
    /// <param name="index">Column index</param>
    public void SortTable(int index)
    {
        WaitForLoading();
        var header = m_control.FindElement(By.CssSelector("thead tr"));
        var cells = header.FindElements(By.CssSelector("th"));

        cells[index].Click();
    }

    /// <summary>
    /// Open the table's column configuration interface
    /// </summary>
    public void OpenColumnConfig()
    {
        // Click the table configuration button which can open a menu or popup,
        // depending on how many configuration interfaces are available
        configBtn?.Click();

        // If there are multiple table configuration options,
        // the table configuration menu should be open
        // and the column configuration button should be clicked
        if (string.Equals(configBtn?.GetDomAttribute("aria-haspopup"), "true"))
            columnConfigBtn?.Click();
    }

	/// <summary>
	/// Toggle row reorder mode
	/// </summary>
	public void ToggleRowReorderMode()
	{
		rowReorderBtn.Click();
	}

    /// <summary>
	/// Toggle column dropdown
	/// </summary>
    /// <param name="columnName">Column's name</param>
	public void ToggleColumnDropdown(string columnName)
    {
        var toggleButton = m_control.FindElement(By.Id(id + "_" + columnName + "_column_drop_toggle"));
        toggleButton.Click();
    }

    /// <summary>
	/// Toggle whether to sort by a column in ascending order
	/// </summary>
    /// <param name="columnName">Column's name</param>
	public void ToggleSortAscending(string columnName)
    {
        ToggleColumnDropdown(columnName);

        var dropdown = new TableColumnDropdown(driver, id, columnName);
        dropdown.SortAscending.Click();
    }

    /// <summary>
	/// Toggle whether to sort by a column in descending order
	/// </summary>
    /// <param name="columnName">Column's name</param>
	public void ToggleSortDescending(string columnName)
    {
        ToggleColumnDropdown(columnName);

        var dropdown = new TableColumnDropdown(driver, id, columnName);
        dropdown.SortDescending.Click();
    }

    /// <summary>
	/// Create a filter
	/// </summary>
    /// <param name="columnName">Column's name</param>
    /// <param name="operation">Operator</param>
    /// <param name="value">Value</param>
	public void FilterByColumn(string columnName, string operation, string value)
    {
        // Open dropdown
        ToggleColumnDropdown(columnName);

        var dropdown = new TableColumnDropdown(driver, id, columnName);

        //Set operation
        dropdown.Operation.SetValue(operation);

        // Set value
        // Must be clicked first or the dropdown will close
        // because of some issue with the framework
        dropdown.Value.Click();
        dropdown.Value.SetValue(value);

        // Apply
        dropdown.Save.Click();
    }

    /// <summary>
	/// Add an advanced filter
	/// </summary>
    /// <param name="columnName">Column's name</param>
    /// <param name="operation">Operator</param>
    /// <param name="value">Value</param>
	public void AddAdvancedFilter(string columnName, string operation, string value)
    {
        if (addAdvancedFilterBtn == null)
            return;

        // Open advanced filter popup
        addAdvancedFilterBtn.Click();

        var advancedFilterPopup = new TableAdvancedFilterNewPage(driver, id);

        advancedFilterPopup.Field.SetValue(columnName);
        advancedFilterPopup.Operation.SetValue(operation);
        advancedFilterPopup.Value.SetValue(value);

        advancedFilterPopup.Save.Click();
    }

    /// <summary>
    /// Gets the count of visible column headers in the table, excluding headers with the "thead-actions" class.
    /// </summary>
    /// <returns>The number of visible column headers, excluding those that have the "thead-actions" class.</returns>
    public int GetVisibleColumnCount()
    {
        WaitForLoading();
        return columns.Count() - NonDataColumnAtBeginningCount();
    }

    /// <summary>
    /// Retrieves the cell element at the specified row and column in the table.
    /// </summary>
    /// <param name="rowIndex">Zero-based index of the row containing the cell.</param>
    /// <param name="columnName">Name of the column whose cell is being retrieved.</param>
    public IWebElement GetCellElement(int rowIndex, string columnName)
    {
        WaitForLoading();

        if (rowIndex < 0 || rowIndex >= RowCount)
            throw new ArgumentOutOfRangeException($"Invalid row index: {rowIndex}");

        int colIndex = GetRawColumnIndex(columnName);
        if (colIndex < 0)
            throw new ArgumentException($"Column not found: {columnName}", nameof(columnName));

        var cells = rows[rowIndex].FindElements(By.TagName("td"));

        return cells[colIndex];
    }

    /// <summary>
    /// Gets the checkbox element for the specified row.
    /// </summary>
    /// <param name="rowIndex">Zero-based index of the row containing the checkbox.</param>
    /// <param name="columnName">Name of the column whose cell contains the checkbox.</param>
    /// <returns>The checkbox element.</returns>
    private IWebElement GetCellCheckbox(int rowIndex, string columnName)
    {
        var cell = GetCellElement(rowIndex, columnName);
        return cell.FindElement(By.CssSelector(".checklist-col-base"));
    }

    /// <summary>
    /// Retrieves the visibility state of the column at the specified index.
    /// Assumes there is a checkbox in the row that indicates the column's visibility.
    /// </summary>
    /// <param name="rowIndex">Zero-based index of the row containing the checkbox.</param>
    /// <param name="columnName">Name of the column whose visibility checkbox should be toggled.</param>
    /// <returns>True if the column is visible; otherwise, false.</returns>
    public bool GetCellCheckboxState(int rowIndex, string columnName)
    {
        WaitForLoading();

        if (rowIndex < 0 || rowIndex >= RowCount)
            throw new ArgumentOutOfRangeException(nameof(rowIndex), $"Invalid row index: {rowIndex}");

        var checkbox = GetCellCheckbox(rowIndex, columnName);
        bool attrValue = checkbox.FindElement(By.CssSelector("input")).Selected;
        return attrValue.Equals(true);
    }

    /// <summary>
    /// Sets the visibility state of the column at the specified index.
    /// If the desired state is different from the current state, the method clicks the checkbox.
    /// </summary>
    /// <param name="rowIndex">Zero-based index of the row containing the checkbox.</param>
    /// <param name="columnName">Name of the column whose visibility checkbox should be toggled.</param>
    /// <param name="visible">Desired visibility state (true for visible, false for hidden).</param>
    public void SetCellCheckboxState(int rowIndex, string columnName, bool visible)
    {
        WaitForLoading();

        if (rowIndex < 0 || rowIndex >= RowCount)
            throw new ArgumentOutOfRangeException(nameof(rowIndex), $"Invalid row index: {rowIndex}");

        var checkbox = GetCellCheckbox(rowIndex, columnName);

        bool currentState = GetCellCheckboxState(rowIndex, columnName);

        if(checkbox != null)
        {
            // Check if the current state differs from the desired state.
            if (currentState != visible)
            {
                // Click the checkbox to toggle its state.
                checkbox.Click();
                // Optionally wait until the checkbox state updates.
                wait.Until(driver => GetCellCheckboxState(rowIndex, columnName) == visible);
            }
        }
    }
}
