using System.Reflection;
using Microsoft.VisualBasic.ApplicationServices;

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

    public override bool Equals(object? obj)
    {
        return obj is Request request &&
               RequestId == request.RequestId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RequestId);
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
