using Microsoft.EntityFrameworkCore;
using ReM.Models;

namespace ReM.View;
public partial class UsersControl : UserControl
{
    private EntityCRUDManager<User> _entityControl = null!;

    public UsersControl()
    {
        InitializeComponent();
    }

    private void Users_Load(object sender, EventArgs e)
    {
        _entityControl = new EntityCRUDManager<User>(dataGridViewUsers)
        {
            DataGridViewAddHandler = DataGridViewAdd,
            DataGridViewChangeValueHandler = DataGridViewChangeValue
        };
        DataViewUpdate();
    }

    private void DataViewUpdate()
    {
        User[] users;
        using (RemContext context = new())
        {
            context.Users.Load();
            users = [.. context.Users.Local];
        }
        _entityControl.DataGridViewUpdate(users);
    }

    private void DataGridViewAdd(DataGridViewRow row, User user)
    {
        row.CreateCells(dataGridViewUsers,
            user.UserId,
            user.Username,
            user.Name,
            user.Surname,
            user.Email,
            user.Phone,
            user.Company,
            user.IsEditor);
    }

    private static bool DataGridViewChangeValue(DataGridView dataGridView, User user, int row, int column)
    {
        var value = dataGridView[column, row].Value;
        var result = string.Empty;
        if (value is not null)
        {
            result = value.ToString() ?? string.Empty;
        }

        if (column == dataGridView.Columns["ColumnUsername"].Index)
        {
            user.Username = result;
        }
        else if (column == dataGridView.Columns["ColumnName"].Index)
        {
            user.Name = result;
        }
        else if (column == dataGridView.Columns["ColumnSurname"].Index)
        {
            user.Surname = result;
        }
        else if (column == dataGridView.Columns["ColumnEmail"].Index)
        {
            user.Email = result;
        }
        else if (column == dataGridView.Columns["ColumnPhone"].Index)
        {
            user.Phone = result;
        }
        else if (column == dataGridView.Columns["ColumnCompany"].Index)
        {
            user.Company = result;
        }
        else if (column == dataGridView.Columns["ColumnIsEditor"].Index)
        {
            user.IsEditor = result;
        }
        else
        {
            return false;
        }
        return true;
    }

    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        DataViewUpdate();
    }

    private void DataGridViewUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
