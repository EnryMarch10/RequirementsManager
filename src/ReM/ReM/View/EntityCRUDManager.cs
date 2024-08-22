using System.ComponentModel;
using System.Diagnostics;
using ReM.Models;

namespace ReM.View;

public partial class EntityCRUDManager<T> where T : notnull, new()
{
    private readonly DataGridView _dataGridView;

    private readonly HashSet<T> _added = [];
    private readonly HashSet<T> _updated = [];

    public HashSet<T> NewItems { get; } = [];
    public HashSet<T> UpdatedItems { get; } = [];
    public HashSet<T> Items { get; private set; } = [];

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

    public EntityCRUDManager(DataGridView dataGridView)
    {
        _dataGridView = dataGridView;
    }

    public void DataGridViewUpdate(ICollection<T> refreshedItems)
    {
        Items = new HashSet<T>(refreshedItems);
        UpdatedItems.Clear();
        NewItems.Clear();

        SortOrder order = _dataGridView.SortOrder;
        DataGridViewColumn columnSorted = _dataGridView.SortedColumn;
        ListSortDirection columnSorting = _dataGridView.SortOrder == SortOrder.Ascending ?
        ListSortDirection.Ascending : ListSortDirection.Descending;
        _dataGridView.Rows.Clear();

        foreach (var item in Items)
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

    public void DataGridView_CellValueChanged(int row, int column)
    {
        if (row != -1 && column != -1)
        {
            if (_dataGridView.Rows[row].Tag is T item)
            {
                if (DataGridViewChangeValueHandler(_dataGridView, item, row, column))
                {
                    Debug.WriteLine($"Request is: {item}");
                    if (!NewItems.Contains(item))
                    {
                        UpdatedItems.Add(item);
                    }
                }
            }
            else
            {
                var newItem = new T();
                DataGridViewChangeValueHandler(_dataGridView, newItem, row, column);
                NewItems.Add(newItem);
                _dataGridView.Rows[row].Tag = newItem;
                Debug.WriteLine($"New request is: {newItem}");
            }
        }
    }

    // These three fucntions should be called in sequence
    public void AddDbData(RemContext context)
    {
        foreach (var item in NewItems)
        {
            var entity = context.Add(item);
            _added.Add((T)entity.Entity);
        }
    }
    public void UpdateDbData(RemContext context)
    {
        foreach (T item in UpdatedItems)
        {
            var entity = context.Update(item);
            _updated.Add((T)entity.Entity);
        }
    }
    public void ReloadSavedDbData()
    {
        var add = _added.Count > 0;
        var update = _updated.Count > 0;
        if (add)
        {
            foreach (var item in NewItems)
            {
                Items.Remove(item);
            }
            foreach (var item in _added)
            {
                Items.Add(item);
            }
            NewItems.Clear();
            _added.Clear();
        }
        if (update)
        {
            foreach (var item in UpdatedItems)
            {
                Items.Remove(item);
            }
            foreach (var item in _updated)
            {
                Items.Add(item);
            }
            UpdatedItems.Clear();
            _updated.Clear();
        }
        if (add || update)
        {
            DataGridViewUpdate(Items);
        }
    }

    public bool AddAndUpdateDbData(bool add = true, bool update = true)
    {
        var result = false;
        if ((!add && !update) ||
            (add && NewItems.Count == 0 && !update) ||
            (!add && update && UpdatedItems.Count == 0) ||
            (add && NewItems.Count == 0 && update && UpdatedItems.Count == 0))
        {
            return result;
        }
        try
        {
            using RemContext context = new();
            DataGridViewBeforeAddingAndUpdatingHandler?.Invoke();
            HashSet<T> added = [];
            if (add)
            {
                foreach (var item in NewItems)
                {
                    DataGridViewBeforeAddingHandler?.Invoke(item);
                    var entity = context.Add(item);
                    added.Add((T)entity.Entity);
                }
            }
            HashSet<T> updated = [];
            if (update)
            {
                foreach (var item in UpdatedItems)
                {
                    DataGridViewBeforeUpdatingHandler?.Invoke(item);
                    var entity = context.Update(item);
                    updated.Add((T)entity.Entity);
                }
            }
            var nUpdates = context.SaveChanges();
            Debug.WriteLine($"Saved {nUpdates} changes");
            foreach (var item in NewItems)
            {
                Items.Remove(item);
            }
            if (add)
            {
                NewItems.Clear();
            }
            foreach (var item in UpdatedItems)
            {
                Items.Remove(item);
            }
            if (update)
            {
                UpdatedItems.Clear();
            }
            foreach (var item in added)
            {
                Items.Add(item);
            }
            foreach (var item in updated)
            {
                Items.Add(item);
            }
            DataGridViewUpdate(Items);
            result = true;
        }
        catch (Exception ex)
        {
            var cause = ex.InnerException is not null ? ex.InnerException.Message : ex.Message;
            MessageBox.Show($"Error occurred when updating {typeof(T).Name}s, try to refresh data.\nMessage: `{cause}`",
                    $"{typeof(T).Name}s manager",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        return result;
    }

    public bool DeleteDbData()
    {
        var result = false;
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
                    UpdatedItems.Remove(item);
                    NewItems.Remove(item);
                    Items.Remove(item);
                }
                result = true;
            }
            catch (Exception ex)
            {
                var cause = ex.InnerException is not null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Error occurred when removing {typeof(T).Name}, try to refresh data.\nMessage: `{cause}`",
                        $"{typeof(T).Name}s manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        return result;
    }
}


