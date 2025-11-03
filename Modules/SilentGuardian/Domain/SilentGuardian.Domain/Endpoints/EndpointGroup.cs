namespace SilentGuardian.Domain.Endpoints;

public class EndpointGroup
{
    public Guid Id { get; private set; }
    public string GroupName { get; private set; }
    public string? Description { get; private set; }
    public bool IsEnabled { get; private set; }
    public List<Endpoint>? Endpoints { get; private set; }
    public bool Result { get;  private set; }   

    public static EndpointGroup Create(string groupName, string? description = null)
    {
        var group = new EndpointGroup();
        
        group.Id = Guid.NewGuid();
        group.GroupName = groupName;
        group.Description = description;
        
        return group;
    }

    public void AddEndpoint(Endpoint endpoint)
    {
        if (Endpoints == null)
            Endpoints = new List<Endpoint>();
        
        if (!Endpoints.Contains(endpoint))
            Endpoints.Add(endpoint);
    }

    public void RemoveEndpoint(Endpoint endpoint)
    {
        if (Endpoints == null)
            return;
        
        if (Endpoints.Contains(endpoint))
            Endpoints.Remove(endpoint);
    }

}