using System.Reflection;

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

    public override bool Equals(object? obj)
    {
        return obj is HistoricRequest request &&
               RequestId == request.RequestId &&
               RequestVersion == request.RequestVersion;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RequestId, RequestVersion);
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
