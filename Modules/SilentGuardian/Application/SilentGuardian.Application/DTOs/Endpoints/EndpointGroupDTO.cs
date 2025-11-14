namespace SilentGuardian.Application.DTOs.Endpoints;

public class EndpointGroupDTO
{
    public Guid Id { get; set; }
    public string GroupName { get; set; }
    public string? Description { get; set; }
    public bool IsEnabled { get; set; }
    public List<EndpointDTO> Endpoints { get; set; } = new List<EndpointDTO>();
    public bool Result { get;  set; }   
}