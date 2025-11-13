namespace SilentGuardian.Application.DTOs.Endpoints;

public class EndpointGroupDTO
{
    public Guid Id { get; private set; }
    public string GroupName { get; private set; }
    public string? Description { get; private set; }
    public bool IsEnabled { get; private set; }
    public List<EndpointDTO> Endpoints { get; private set; } = new List<EndpointDTO>();
    public bool Result { get;  private set; }   
}