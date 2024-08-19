using System.ComponentModel;
using System.Diagnostics;
using ReM.Models;
using Microsoft.EntityFrameworkCore;

namespace ReM.View;

public partial class Users : UserControl
{
    private List<User> _users = [];

    public Users()
    {
        InitializeComponent();
    }

    private void Users_Load(object sender, EventArgs e)
    {
        DataGridView_Update();
    }

    private void DataGridView_Add(User user)
    {
        DataGridViewRow row = (DataGridViewRow)dataGridViewUsers.RowTemplate.Clone();
        row.CreateCells(dataGridViewUsers,
            user.UserId,
            user.Username,
            user.Name,
            user.Surname,
            user.Email,
            user.Phone,
            user.Company,
            user.IsEditor);
        row.Tag = user;
        dataGridViewUsers.Rows.Add(row);
    }

    private void DataGridView_Update(ICollection<User> users)
    {
        SortOrder order = dataGridViewUsers.SortOrder;
        DataGridViewColumn columnSorted = dataGridViewUsers.SortedColumn;
        ListSortDirection columnSorting = dataGridViewUsers.SortOrder == SortOrder.Ascending ?
            ListSortDirection.Ascending : ListSortDirection.Descending;
        dataGridViewUsers.Rows.Clear();

        foreach (User user in users)
        {
            DataGridView_Add(user);
        }
        if ((columnSorted != null) && (order != SortOrder.None))
        {
            dataGridViewUsers.Sort(columnSorted, columnSorting);
        }
    }

    private void DataGridView_Update()
    {
        using RemContext context = new();
        context.Users.Load();
        _users = [.. context.Users.Local];
        DataGridView_Update(_users);
    }

    private bool DataGridView_ChangeValue(User user, int row, int column)
    {
        var value = dataGridViewUsers[column, row].Value;
        var result = string.Empty;
        if (value is not null)
        {
            result = value.ToString() ?? string.Empty;
        }
        switch (column)
        {
            case 1: user.Username = result; break;
            case 2: user.Name = result; break;
            case 3: user.Surname = result; break;
            case 4: user.Email = result; break;
            case 5: user.Phone = result; break;
            case 6: user.Company = result; break;
            case 7: user.IsEditor = result; break;
            default: return false;
        }
        return true;
    }

    private void DataGridViewUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != -1 && e.RowIndex != -1)
        {
            if (dataGridViewUsers.Rows[e.RowIndex].Tag is User user)
            {
                if (DataGridView_ChangeValue(user, e.RowIndex, e.ColumnIndex))
                {
                    Debug.WriteLine($"User is: {user}");
                }
            }
            else
            {
                var newUser = new User();
                DataGridView_ChangeValue(newUser, e.RowIndex, e.ColumnIndex);
                _users.Add(newUser);
                dataGridViewUsers.Rows[e.RowIndex].Tag = newUser;
                Debug.WriteLine($"New user is: {newUser}");
            }
        }
    }

    private void ButtonUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            using RemContext context = new();
            context.Users.UpdateRange(_users);
            var nUpdates = context.SaveChanges();
            Debug.WriteLine($"Saved {nUpdates} changes");
        }
        catch (Exception)
        {
            MessageBox.Show("Error occurred when updating users, try to refresh data.",
                    "User insertion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }

    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        DataGridView_Update();
    }

    private void ButtonDelete_Click(object sender, EventArgs e)
    {
        var selectedRows = dataGridViewUsers.SelectedRows;
        Debug.WriteLine($"Selected rows count = {selectedRows.Count}");
        if (selectedRows.Count == 1 && selectedRows[0].Tag is User user)
        {
            try
            {
                using RemContext context = new();
                context.Remove(user);
                var nUpdates = context.SaveChanges();
                Debug.WriteLine($"Saved {nUpdates} changes");
                if (nUpdates == 1)
                {
                    dataGridViewUsers.Rows.RemoveAt(selectedRows[0].Index);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred when removing user, try to refresh data.",
                        "User removal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
    }
}
