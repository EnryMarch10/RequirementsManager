using System.Reflection;

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

    public virtual ICollection<HistoricRequest> HistoricRequestUserIdApprovalNavigations { get; set; } = new List<HistoricRequest>();

    public virtual ICollection<HistoricRequest> HistoricRequestUserIdEditingNavigations { get; set; } = new List<HistoricRequest>();

    public virtual ICollection<HistoricRequirement> HistoricRequirements { get; set; } = new List<HistoricRequirement>();

    public virtual ICollection<Release> Releases { get; set; } = new List<Release>();

    public virtual ICollection<Request> RequestUserIdApprovalNavigations { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestUserIdCreationNavigations { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestUserIdEditingNavigations { get; set; } = new List<Request>();

    public virtual ICollection<Requirement> RequirementUserIdCreationNavigations { get; set; } = new List<Requirement>();

    public virtual ICollection<Requirement> RequirementUserIdEditingNavigations { get; set; } = new List<Requirement>();

    public override bool Equals(object? obj)
    {
        return obj is User user &&
               UserId == user.UserId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(UserId);
    }

    public override string ToString()
    {
        // Using StringBuilder for efficient string concatenation
        var result = new System.Text.StringBuilder();

        // Get the type of the current instance
        Type type = GetType();

        // Get all public properties of the type
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Iterate through each property
        foreach (PropertyInfo property in properties)
        {
            // Get the property name and value
            string propertyName = property.Name;
            object? propertyValue = property.GetValue(this);

            // Append the property name and value to the result
            result.AppendLine($"{propertyName}: {propertyValue ?? "NULL"}");
        }

        return result.ToString();
    }
}
