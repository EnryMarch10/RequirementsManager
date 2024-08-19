namespace ReM.Models;

public partial class User
{
    public uint UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Company { get; set; }

    public string IsEditor { get; set; } = null!;

    public virtual ICollection<HistoricRequest> HistoricRequests { get; set; } = new List<HistoricRequest>();

    public virtual ICollection<HistoricRequirement> HistoricRequirements { get; set; } = new List<HistoricRequirement>();

    public virtual ICollection<Release> Releases { get; set; } = new List<Release>();

    public virtual ICollection<Request> RequestUserIdApprovalNavigations { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestUserIdCreationNavigations { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestUserIdEditingNavigations { get; set; } = new List<Request>();

    public virtual ICollection<Requirement> RequirementUserIdCreationNavigations { get; set; } = new List<Requirement>();

    public virtual ICollection<Requirement> RequirementUserIdEditingNavigations { get; set; } = new List<Requirement>();
}
