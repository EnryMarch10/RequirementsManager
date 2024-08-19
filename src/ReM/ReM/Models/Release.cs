namespace ReM.Models;

public partial class Release
{
    public string ReleaseName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime TimeCreation { get; set; }

    public uint NRequests { get; set; }

    public uint NRequirements { get; set; }

    public uint UserIdCreation { get; set; }

    public virtual ICollection<HistoricRequest> HistoricRequests { get; set; } = new List<HistoricRequest>();

    public virtual ICollection<HistoricRequirement> HistoricRequirements { get; set; } = new List<HistoricRequirement>();

    public virtual User UserIdCreationNavigation { get; set; } = null!;
}
