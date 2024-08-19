namespace ReM.Models;

public partial class Request
{
    public uint RequestId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[]? Body { get; set; }

    public string Type { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public uint UserIdCreation { get; set; }

    public DateTime TimeCreation { get; set; }

    public uint UserIdEditing { get; set; }

    public DateTime TimeEditing { get; set; }

    public uint? UserIdApproval { get; set; }

    public DateTime? TimeApproval { get; set; }

    public virtual ICollection<HistoricRequest> HistoricRequests { get; set; } = new List<HistoricRequest>();

    public virtual ICollection<Requirement> Requirements { get; set; } = new List<Requirement>();

    public virtual User? UserIdApprovalNavigation { get; set; }

    public virtual User UserIdCreationNavigation { get; set; } = null!;

    public virtual User UserIdEditingNavigation { get; set; } = null!;
}
