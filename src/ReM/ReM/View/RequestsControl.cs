using Microsoft.EntityFrameworkCore;
using ReM.Models;

namespace ReM.View;
public partial class RequestsControl : UserControl
{
    private EntityCRUDManager<Request> _entityControl = null!;
    private DateTime time;

    public RequestsControl()
    {
        InitializeComponent();
    }

    private void Requests_Load(object sender, EventArgs e)
    {
        _entityControl = new EntityCRUDManager<Request>(dataGridViewRequests)
        {
            DataGridViewAddHandler = DataGridView_Add,
            DataGridViewChangeValueHandler = DataGridViewChangeValue,
            DataGridViewBeforeAddingHandler = BeforeAdding,
            DataGridViewBeforeUpdatingHandler = BeforeUpdating,
            DataGridViewBeforeAddingAndUpdatingHandler = BeforeAddingAndUpdating
        };
        DataGridViewUpdate();
    }

    private void DataGridViewUpdate()
    {
        Request[] requests;
        using (RemContext context = new())
        {
            context.Requests.Load();
            requests = [.. context.Requests.Local];
        }
        _entityControl.DataGridViewUpdate(requests);
    }

    private void DataGridView_Add(DataGridViewRow row, Request request)
    {
        row.CreateCells(dataGridViewRequests,
            request.RequestId,
            request.Title,
            request.Description,
            request.Body is not null ? "DATA" : null,
            request.Type,
            request.IsActive,
            request.UserIdCreation,
            request.TimeCreation,
            request.UserIdEditing,
            request.TimeEditing,
            request.UserIdApproval,
            request.TimeApproval);
    }

    private static bool DataGridViewChangeValue(DataGridView dataGridView, Request request, int row, int column)
    {
        var value = dataGridView[column, row].Value;
        var result = string.Empty;
        if (value is not null)
        {
            result = value.ToString() ?? string.Empty;
        }
        if (column == dataGridView.Columns["ColumnTitle"].Index)
        {
            request.Title = result;
        }
        else if (column == dataGridView.Columns["ColumnDescription"].Index)
        {
            request.Description = result;
        }
        else if (column == dataGridView.Columns["ColumnType"].Index)
        {
            request.Type = result;
        }
        else if (column == dataGridView.Columns["ColumnIsActive"].Index)
        {
            request.IsActive = result;
        }
        else if (column == dataGridView.Columns["ColumnUserIdCreation"].Index)
        {
            request.UserIdCreation = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnUserIdEditing"].Index)
        {
            request.UserIdEditing = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnTimeEditing"].Index)
        {
            request.TimeEditing = DateTime.TryParse(result, out DateTime date) ? date : DateTime.Now;
        }
        else if (column == dataGridView.Columns["ColumnUserIdApproval"].Index)
        {
            request.UserIdApproval = uint.TryParse(result, out uint index) ? index : 0;
        }
        else if (column == dataGridView.Columns["ColumnTimeApproval"].Index)
        {
            request.TimeApproval = DateTime.TryParse(result, out DateTime date) ? date : DateTime.Now;
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
    private void BeforeAdding(Request request)
    {
        request.TimeApproval = request.UserIdApproval is not null ? time : null;
        request.TimeEditing = time;
    }
    private void BeforeUpdating(Request request)
    {
        request.TimeApproval = request.UserIdApproval is not null ? time : null;
        request.TimeEditing = time;
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
