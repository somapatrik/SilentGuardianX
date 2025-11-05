namespace SilentGuardian.Domain.Endpoints;

public class EndpointGroup
{
    public Guid Id { get; private set; }
    public string GroupName { get; private set; }
    public string? Description { get; private set; }
    public bool IsEnabled { get; private set; }
    public List<Endpoint> Endpoints { get; private set; } = new List<Endpoint>();
    public bool Result { get;  private set; }   

    public static EndpointGroup Create(string groupName, string? description = null)
    {
        var group = new EndpointGroup();
        group.Id = Guid.NewGuid();
        group.SetName(groupName);
        group.Description = description;
        return group;
    }

    private void SetName(string groupName)
    {
        if (string.IsNullOrWhiteSpace(groupName))
            throw new ArgumentNullException(nameof(groupName));
        
        if (groupName.Length > 50)
            throw new ArgumentOutOfRangeException(nameof(groupName));
        
        GroupName = groupName.Trim();
    }
    
    public void AddEndpoint(Endpoint endpoint)
    {
        if (!Endpoints.Contains(endpoint))
            Endpoints.Add(endpoint);
    }

    public void RemoveEndpoint(Endpoint endpoint)
    {
        Endpoints.Remove(endpoint);
    }

}