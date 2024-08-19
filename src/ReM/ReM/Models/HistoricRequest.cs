namespace ReM.Models;

public partial class HistoricRequest
{
    public uint RequestId { get; set; }

    public uint RequestVersion { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[]? Body { get; set; }

    public string Type { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public uint UserIdEditing { get; set; }

    public DateTime TimeEditing { get; set; }

    public DateTime TimeApproval { get; set; }

    public string ReleaseName { get; set; } = null!;

    public virtual ICollection<HistoricRequirement> HistoricRequirements { get; set; } = new List<HistoricRequirement>();

    public virtual Release ReleaseNameNavigation { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;

    public virtual User UserIdEditingNavigation { get; set; } = null!;
}
