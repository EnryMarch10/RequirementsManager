using System.ComponentModel;
using System.Diagnostics;
using ReM.Models;

namespace ReM.View;

public partial class EntityControl<T> where T : new()
{
    private readonly DataGridView _dataGridView;
    private readonly HashSet<T> _newItems = [];
    private readonly HashSet<T> _updatedItems = [];
    private HashSet<T> _items = [];

    public delegate void DataGridViewAddDelegate(DataGridViewRow row, T item);
    public delegate bool DataGridViewChangeValueDelegate(DataGridView dataGridView, T item, int row, int column);
    public delegate void DataGridViewBeforeAddingDelegate(T item);
    public delegate void DataGridViewBeforeUpdatingDelegate(T item);
    public delegate void DataGridViewBeforeAddingAndUpdatingDelegate();

    public DataGridViewAddDelegate DataGridViewAddHandler { get; set; } = null!;
    public DataGridViewChangeValueDelegate DataGridViewChangeValueHandler { get; set; } = null!;
    public DataGridViewBeforeAddingDelegate DataGridViewBeforeAddingHandler { get; set; } = null!;
    public DataGridViewBeforeUpdatingDelegate DataGridViewBeforeUpdatingHandler { get; set; } = null!;
    public DataGridViewBeforeAddingAndUpdatingDelegate DataGridViewBeforeAddingAndUpdatingHandler { get; set; } = null!;

    public EntityControl(DataGridView dataGridView)
    {
        _dataGridView = dataGridView;
    }

    public void DataGridViewUpdate(ICollection<T> refreshedItems)
    {
        _items = new HashSet<T>(refreshedItems);
        _updatedItems.Clear();
        _newItems.Clear();

        SortOrder order = _dataGridView.SortOrder;
        DataGridViewColumn columnSorted = _dataGridView.SortedColumn;
        ListSortDirection columnSorting = _dataGridView.SortOrder == SortOrder.Ascending ?
        ListSortDirection.Ascending : ListSortDirection.Descending;
        _dataGridView.Rows.Clear();

        foreach (var item in _items)
        {
            DataGridViewRow row = (DataGridViewRow)_dataGridView.RowTemplate.Clone();
            DataGridViewAddHandler(row, item);
            row.Tag = item;
            _dataGridView.Rows.Add(row);
        }
        if ((columnSorted != null) && (order != SortOrder.None))
        {
            _dataGridView.Sort(columnSorted, columnSorting);
        }
    }

    public void DataGridViewUsersCellValueChanged(int row, int column)
    {
        if (row != -1 && column != -1)
        {
            if (_dataGridView.Rows[row].Tag is T item)
            {
                if (DataGridViewChangeValueHandler(_dataGridView, item, row, column))
                {
                    Debug.WriteLine($"Request is: {item}");
                    if (!_newItems.Contains(item))
                    {
                        _updatedItems.Add(item);
                    }
                }
            }
            else
            {
                var newItem = new T();
                DataGridViewChangeValueHandler(_dataGridView, newItem, row, column);
                _newItems.Add(newItem);
                _dataGridView.Rows[row].Tag = newItem;
                Debug.WriteLine($"New request is: {newItem}");
            }
        }
    }

    public void ButtonUpdateClick()
    {
        try
        {
            using RemContext context = new();
            DataGridViewBeforeAddingAndUpdatingHandler?.Invoke();
            HashSet<T> added = [];
            foreach (var item in _newItems)
            {
                if (item is not null)
                {
                    DataGridViewBeforeAddingHandler?.Invoke(item);
                    var entity = context.Add(item);
                    added.Add((T)entity.Entity);
                }
            }
            HashSet<T> updated = [];
            foreach (var item in _updatedItems)
            {
                if (item is not null)
                {
                    DataGridViewBeforeUpdatingHandler?.Invoke(item);
                    var entity = context.Update(item);
                    updated.Add((T)entity.Entity);
                }
            }
            var nUpdates = context.SaveChanges();
            Debug.WriteLine($"Saved {nUpdates} changes");
            foreach (var item in _newItems)
            {
                _items.Remove(item);
            }
            _newItems.Clear();
            foreach (var item in _updatedItems)
            {
                _items.Remove(item);
            }
            _updatedItems.Clear();
            foreach (var item in added)
            {
                _items.Add(item);
            }
            foreach (var item in updated)
            {
                _items.Add(item);
            }
            DataGridViewUpdate(_items);
        }
        catch (Exception ex)
        {
            var cause = ex.InnerException is not null ? ex.InnerException.Message : ex.Message;
            MessageBox.Show($"Error occurred when updating {typeof(T).Name}s, try to refresh data.\nMessage: `{cause}`",
                    $"{typeof(T).Name}s update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }

    public void ButtonDeleteClick()
    {
        var selectedRows = _dataGridView.SelectedRows;
        Debug.WriteLine($"Selected rows count = {selectedRows.Count}");
        if (selectedRows.Count == 1 && selectedRows[0].Tag is T item)
        {
            try
            {
                using RemContext context = new();
                context.Remove(item);
                var nUpdates = context.SaveChanges();
                Debug.WriteLine($"Saved {nUpdates} changes");
                if (nUpdates == 1)
                {
                    _dataGridView.Rows.RemoveAt(selectedRows[0].Index);
                    _updatedItems.Remove(item);
                    _newItems.Remove(item);
                    _items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                var cause = ex.InnerException is not null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Error occurred when removing {typeof(T).Name}, try to refresh data.\nMessage: `{cause}`",
                        $"{typeof(T).Name} removal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
    }
}


