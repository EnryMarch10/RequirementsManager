using Microsoft.EntityFrameworkCore;
using ReM.Models;

namespace ReM.View;

public partial class ReleasesControl : UserControl
{
    private EntityCRUDManager<Release> _entityControl = null!;

    public ReleasesControl()
    {
        InitializeComponent();
    }

    private void Releases_Load(object sender, EventArgs e)
    {
        _entityControl = new EntityCRUDManager<Release>(dataGridViewReleases)
        {
            DataGridViewAddHandler = DataGridViewAdd,
            DataGridViewChangeValueHandler = DataGridViewChangeValue
        };
        DataGridViewUpdate();
    }

    private void DataGridViewUpdate()
    {
        Release[] releases;
        using (RemContext context = new())
        {
            context.Releases.Load();
            releases = [.. context.Releases.Local];
        }
        _entityControl.DataGridViewUpdate(releases);
    }

    private void DataGridViewAdd(DataGridViewRow row, Release release)
    {
        row.CreateCells(dataGridViewReleases,
            release.ReleaseName,
            release.Description,
            release.TimeCreation,
            release.NRequests,
            release.NRequirements,
            release.UserIdCreation);
    }

    private static bool DataGridViewChangeValue(DataGridView dataGridView, Release release, int row, int column)
    {
        var value = dataGridView[column, row].Value;
        var result = string.Empty;
        if (value is not null)
        {
            result = value.ToString() ?? string.Empty;
        }

        if (column == dataGridView.Columns["ColumnReleaseName"].Index)
        {
            release.ReleaseName = result;
        }
        else if (column == dataGridView.Columns["ColumnDescription"].Index)
        {
            release.Description = result;
        }
        else if (column == dataGridView.Columns["ColumnUserIdCreation"].Index)
        {
            release.UserIdCreation = uint.TryParse(result, out uint id) ? id : 0;
        }
        else
        {
            return false;
        }
        return true;
    }

    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        DataGridViewUpdate();
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
