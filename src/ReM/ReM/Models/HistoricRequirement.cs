namespace ReM.Models;

public partial class HistoricRequirement
{
    public uint RequirementId { get; set; }

    public uint RequirementVersion { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[]? Body { get; set; }

    public string Type { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public uint UserIdEditing { get; set; }

    public DateTime TimeEditing { get; set; }

    public float EstimatedHours { get; set; }

    public float TakenHours { get; set; }

    public uint RequestId { get; set; }

    public uint RequestVersion { get; set; }

    public uint? ParentRequirementId { get; set; }

    public uint? ParentRequirementVersion { get; set; }

    public string ReleaseName { get; set; } = null!;

    public virtual HistoricRequest HistoricRequest { get; set; } = null!;

    public virtual HistoricRequirement? HistoricRequirementNavigation { get; set; }

    public virtual ICollection<HistoricRequirement> InverseHistoricRequirementNavigation { get; set; } = new List<HistoricRequirement>();

    public virtual Release ReleaseNameNavigation { get; set; } = null!;

    public virtual Requirement Requirement { get; set; } = null!;

    public virtual User UserIdEditingNavigation { get; set; } = null!;
}
