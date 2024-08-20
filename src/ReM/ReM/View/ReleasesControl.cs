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
            release.ReleaseId,
            release.Name,
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

        if (column == dataGridView.Columns["ColumnName"].Index)
        {
            release.Name = result;
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
        var newItems = _entityControl.NewItems.ToArray();
        var updatedItems = _entityControl.UpdatedItems.ToArray();
        Request[] requests;
        Requirement[] requirements;
        HistoricRequest[] historicRequests;
        HistoricRequirement[] historicRequirements;
        using (RemContext context = new())
        {
            context.Requests.Load();
            context.Requirements.Load();
            context.HistoricRequests.Load();
            context.HistoricRequirements.Load();
            requests = context.Requests.Local.ToArray();
            requirements = context.Requirements.Local.ToArray();
            historicRequests = context.HistoricRequests.Local.ToArray();
            historicRequirements = context.HistoricRequirements.Local.ToArray();
        }
        bool addReleases = true;
        if (newItems.Length > 0 && requests.Any(request => request.UserIdApproval is null || request.TimeApproval is null))
        {
            MessageBox.Show($"Impossible to add Releases if all Requests aren't approved.",
                        "Releases manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            addReleases = false;
        }
        uint count = 1;
        var randomRequest = historicRequests.FirstOrDefault();
        if (randomRequest is not null)
        {
            count += (uint) historicRequests.Count(req => req.RequestId == randomRequest.RequestId);
        }
        if (_entityControl.AddAndUpdateDbData(addReleases) && addReleases)
        {
            foreach (var release in newItems)
            {
                try
                {
                    using RemContext context = new();
                    context.HistoricRequests.AddRange(requests.Select(req => new HistoricRequest()
                    {
                        RequestId = req.RequestId,
                        RequestVersion = count,
                        Title = req.Title,
                        Description = req.Description,
                        Body = req.Body,
                        Type = req.Type,
                        IsActive = req.IsActive,
                        UserIdEditing = req.UserIdEditing,
                        TimeEditing = req.TimeEditing,
                        UserIdApproval = (uint) req.UserIdApproval,
                        TimeApproval = (DateTime) req.TimeApproval,
                        ReleaseId = release.ReleaseId
                    }));
                    context.HistoricRequirements.AddRange(requirements.Select(req => new HistoricRequirement()
                    {
                        RequirementId = req.RequirementId,
                        RequirementVersion = count,
                        Title = req.Title,
                        Description = req.Description,
                        Body = req.Body,
                        Type = req.Type,
                        IsActive = req.IsActive,
                        UserIdEditing = req.UserIdEditing,
                        TimeEditing = req.TimeEditing,
                        EstimatedHours = req.EstimatedHours,
                        TakenHours = req.TakenHours,
                        RequestId = req.RequestId,
                        RequestVersion = count,
                        ParentRequirementId = req.ParentRequirementId,
                        ParentRequirementVersion = req.ParentRequirementId is null ? null : count,
                        ReleaseId = release.ReleaseId
                    }));
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var cause = ex.InnerException is not null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show($"Error occurred while managing historic Requests and Requirements, try to refresh data.\nMessage: `{cause}`",
                            "Releases manager",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
        }
    }

    private void ButtonDelete_Click(object sender, EventArgs e)
    {
        _entityControl.DeleteDbData();
    }
}
