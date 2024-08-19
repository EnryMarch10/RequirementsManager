namespace ReM.Models;

public partial class Requirement
{
    public uint RequirementId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[]? Body { get; set; }

    public string Type { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public uint UserIdCreation { get; set; }

    public DateTime TimeCreation { get; set; }

    public uint UserIdEditing { get; set; }

    public DateTime TimeEditing { get; set; }

    public uint ProgressPercentage { get; set; }

    public float EstimatedHours { get; set; }

    public float TakenHours { get; set; }

    public uint RequestId { get; set; }

    public uint? ParentRequirementId { get; set; }

    public virtual ICollection<HistoricRequirement> HistoricRequirements { get; set; } = new List<HistoricRequirement>();

    public virtual ICollection<Requirement> InverseParentRequirement { get; set; } = new List<Requirement>();

    public virtual Requirement? ParentRequirement { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual User UserIdCreationNavigation { get; set; } = null!;

    public virtual User UserIdEditingNavigation { get; set; } = null!;
}
