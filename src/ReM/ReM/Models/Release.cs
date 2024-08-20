using System.Reflection;

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

    public override bool Equals(object? obj)
    {
        return obj is Release release &&
               ReleaseName == release.ReleaseName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ReleaseName);
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
