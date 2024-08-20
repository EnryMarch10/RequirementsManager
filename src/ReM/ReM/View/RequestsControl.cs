using ReM.Models;
using Microsoft.EntityFrameworkCore;

namespace ReM.View;

public partial class RequestsControl : UserControl
{
    private EntityControl<Request> _entityControl = null!;
    private DateTime time;

    public RequestsControl()
    {
        InitializeComponent();
    }

    private void Requests_Load(object sender, EventArgs e)
    {
        _entityControl = new EntityControl<Request>(dataGridViewRequests)
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
        Request[] requests;
        using (RemContext context = new())
        {
            context.Requests.Load();
            requests = [.. context.Requests.Local];
        }
        _entityControl.DataGridViewUpdate(requests);
    }

    protected void DataGridView_Add(DataGridViewRow row, Request item)
    {
        row.CreateCells(dataGridViewRequests,
            item.RequestId,
            item.Title,
            item.Description,
            item.Body is not null ? "DATA" : null,
            item.Type,
            item.IsActive,
            item.UserIdCreation,
            item.TimeCreation,
            item.UserIdEditing,
            item.TimeEditing,
            item.UserIdApproval,
            item.TimeApproval);
    }

    private static bool DataGridViewChangeValue(DataGridView dataGridView, Request item, int row, int column)
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
        else if (column == dataGridView.Columns["ColumnUserIdApproval"].Index)
        {
            item.UserIdApproval = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnTimeApproval"].Index)
        {
            item.TimeApproval = DateTime.TryParse(result, out DateTime date) ? date : DateTime.Now;
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
    private void BeforeAdding(Request item)
    {
        item.TimeEditing = time;
    }
    private void BeforeUpdating(Request item)
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
