using Microsoft.EntityFrameworkCore;
using ReM.Models;

namespace ReM.View;
public partial class RequirementsControl : UserControl
{
    private EntityCRUDManager<Requirement> _entityControl = null!;
    private DateTime time;

    public RequirementsControl()
    {
        InitializeComponent();
    }

    private void Requirements_Load(object sender, EventArgs e)
    {
        _entityControl = new EntityCRUDManager<Requirement>(dataGridViewRequirements)
        {
            DataGridViewAddHandler = DataGridViewAdd,
            DataGridViewChangeValueHandler = DataGridViewChangeValue,
            DataGridViewBeforeAddingHandler = BeforeAdding,
            DataGridViewBeforeUpdatingHandler = BeforeUpdating,
            DataGridViewBeforeAddingAndUpdatingHandler = BeforeAddingAndUpdating
        };
        DataGridViewUpdate();
    }

    private void DataGridViewUpdate()
    {
        Requirement[] requirements;
        using (RemContext context = new())
        {
            context.Requirements.Load();
            requirements = [.. context.Requirements.Local];
        }
        _entityControl.DataGridViewUpdate(requirements);
    }

    private void DataGridViewAdd(DataGridViewRow row, Requirement requirement)
    {
        row.CreateCells(dataGridViewRequirements,
            requirement.RequirementId,
            requirement.Title,
            requirement.Description,
            requirement.Body is not null ? "DATA" : null,
            requirement.Type,
            requirement.IsActive,
            requirement.UserIdCreation,
            requirement.TimeCreation,
            requirement.UserIdEditing,
            requirement.TimeEditing,
            requirement.ProgressPercentage,
            requirement.EstimatedHours,
            requirement.TakenHours,
            requirement.RequestId,
            requirement.ParentRequirementId);
    }

    private static bool DataGridViewChangeValue(DataGridView dataGridView, Requirement requirement, int row, int column)
    {
        var value = dataGridView[column, row].Value;
        var result = string.Empty;
        if (value is not null)
        {
            result = value.ToString() ?? string.Empty;
        }
        if (column == dataGridView.Columns["ColumnTitle"].Index)
        {
            requirement.Title = result;
        }
        else if (column == dataGridView.Columns["ColumnDescription"].Index)
        {
            requirement.Description = result;
        }
        else if (column == dataGridView.Columns["ColumnType"].Index)
        {
            requirement.Type = result;
        }
        else if (column == dataGridView.Columns["ColumnIsActive"].Index)
        {
            requirement.IsActive = result;
        }
        else if (column == dataGridView.Columns["ColumnUserIdCreation"].Index)
        {
            requirement.UserIdCreation = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnUserIdEditing"].Index)
        {
            requirement.UserIdEditing = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnTimeEditing"].Index)
        {
            requirement.TimeEditing = DateTime.TryParse(result, out DateTime date) ? date : DateTime.Now;
        }
        else if (column == dataGridView.Columns["ColumnProgressPercentage"].Index)
        {
            requirement.ProgressPercentage = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnEstimatedHours"].Index)
        {
            requirement.EstimatedHours = float.TryParse(result, out float index) ? index : 0.0f;
        }
        else if (column == dataGridView.Columns["ColumnTakenHours"].Index)
        {
            requirement.TakenHours = float.TryParse(result, out float index) ? index : 0.0f;
        }
        else if (column == dataGridView.Columns["ColumnRequestId"].Index)
        {
            requirement.RequestId = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnParentRequirementId"].Index)
        {
            requirement.ParentRequirementId = uint.TryParse(result, out uint index) ? index : null;
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
    private void BeforeAdding(Requirement requirement)
    {
        requirement.TimeEditing = time;
    }
    private void BeforeUpdating(Requirement requirement)
    {
        requirement.TimeEditing = time;
    }

    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        DataGridViewUpdate();
    }

    private void DataGridViewRequests_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        _entityControl?.DataGridView_CellValueChanged(e.RowIndex, e.ColumnIndex);
    }

    private void ButtonUpdate_Click(object sender, EventArgs e)
    {
        _entityControl.AddAndUpdateDbData();
    }

    private void ButtonDelete_Click(object sender, EventArgs e)
    {
        _entityControl.DeleteDbData();
    }
}
