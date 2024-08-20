using ReM.Models;
using Microsoft.EntityFrameworkCore;

namespace ReM.View;

public partial class RequirementsControl : UserControl
{
    private EntityControl<Requirement> _entityControl = null!;
    private DateTime time;

    public RequirementsControl()
    {
        InitializeComponent();
    }

    private void Requests_Load(object sender, EventArgs e)
    {
        _entityControl = new EntityControl<Requirement>(dataGridViewRequirements)
        {
            DataGridViewAddHandler = DataGridView_Add,
            DataGridViewChangeValueHandler = DataGridViewChangeValue,
            DataGridViewBeforeAddingHandler = BeforeAdding,
            DataGridViewBeforeUpdatingHandler = BeforeUpdating,
            DataGridViewBeforeAddingAndUpdatingHandler = BeforeAddingAndUpdating
        };
        DataViewUpdate();
    }

    private void DataViewUpdate()
    {
        Requirement[] requirements;
        using (RemContext context = new())
        {
            context.Requirements.Load();
            requirements = [.. context.Requirements.Local];
        }
        _entityControl.DataGridViewUpdate(requirements);
    }

    protected void DataGridView_Add(DataGridViewRow row, Requirement item)
    {
        row.CreateCells(dataGridViewRequirements,
            item.RequirementId,
            item.Title,
            item.Description,
            item.Body is not null ? "DATA" : null,
            item.Type,
            item.IsActive,
            item.UserIdCreation,
            item.TimeCreation,
            item.UserIdEditing,
            item.TimeEditing,
            item.ProgressPercentage,
            item.EstimatedHours,
            item.TakenHours,
            item.RequestId,
            item.ParentRequirementId);
    }

    private static bool DataGridViewChangeValue(DataGridView dataGridView, Requirement item, int row, int column)
    {
        var value = dataGridView[column, row].Value;
        var result = string.Empty;
        if (value is not null)
        {
            result = value.ToString() ?? string.Empty;
        }
        if (column == dataGridView.Columns["ColumnTitle"].Index)
        {
            item.Title = result;
        }
        else if (column == dataGridView.Columns["ColumnDescription"].Index)
        {
            item.Description = result;
        }
        else if (column == dataGridView.Columns["ColumnType"].Index)
        {
            item.Type = result;
        }
        else if (column == dataGridView.Columns["ColumnIsActive"].Index)
        {
            item.IsActive = result;
        }
        else if (column == dataGridView.Columns["ColumnUserIdCreation"].Index)
        {
            item.UserIdCreation = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnUserIdEditing"].Index)
        {
            item.UserIdEditing = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnTimeEditing"].Index)
        {
            item.TimeEditing = DateTime.TryParse(result, out DateTime date) ? date : DateTime.Now;
        }
        else if (column == dataGridView.Columns["ColumnProgressPercentage"].Index)
        {
            item.ProgressPercentage = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnEstimatedHours"].Index)
        {
            item.EstimatedHours = float.TryParse(result, out float index) ? index : 0.0f;
        }
        else if (column == dataGridView.Columns["ColumnTakenHours"].Index)
        {
            item.TakenHours = float.TryParse(result, out float index) ? index : 0.0f;
        }
        else if (column == dataGridView.Columns["ColumnRequestId"].Index)
        {
            item.RequestId = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnParentRequirementId"].Index)
        {
            item.ParentRequirementId = uint.TryParse(result, out uint index) ? index : null;
        }
        else
        {
            return false;
        }
        return true;
    }

    // Following three functions are called in sequence
    private void BeforeAddingAndUpdating()
    {
        time = DateTime.Now;
    }
    private void BeforeAdding(Requirement item)
    {
        item.TimeEditing = time;
    }
    private void BeforeUpdating(Requirement item)
    {
        item.TimeEditing = time;
    }

    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        DataViewUpdate();
    }

    private void DataGridViewRequests_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        _entityControl?.DataGridViewUsersCellValueChanged(e.RowIndex, e.ColumnIndex);
    }

    private void ButtonUpdate_Click(object sender, EventArgs e)
    {
        _entityControl.ButtonUpdateClick();
    }

    private void ButtonDelete_Click(object sender, EventArgs e)
    {
        _entityControl.ButtonDeleteClick();
    }
}
