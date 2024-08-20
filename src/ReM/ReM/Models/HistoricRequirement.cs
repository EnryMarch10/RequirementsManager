using System.Reflection;

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

    public uint ReleaseId { get; set; }

    public virtual HistoricRequest HistoricRequest { get; set; } = null!;

    public virtual HistoricRequirement? HistoricRequirementNavigation { get; set; }

    public virtual ICollection<HistoricRequirement> InverseHistoricRequirementNavigation { get; set; } = new List<HistoricRequirement>();

    public virtual Release Release { get; set; } = null!;

    public virtual Requirement Requirement { get; set; } = null!;

    public virtual User UserIdEditingNavigation { get; set; } = null!;

    public override bool Equals(object? obj)
    {
        return obj is HistoricRequirement requirement &&
               RequirementId == requirement.RequirementId &&
               RequirementVersion == requirement.RequirementVersion;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RequirementId, RequirementVersion);
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
