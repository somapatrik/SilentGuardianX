namespace SilentGuardian.Application.DTOs.Endpoints;

public class EndpointDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsEnabled { get; set; }
    public EndpointResultDTO Result { get; set; }
    public List<CheckMethodDTO> CheckMethods { get; set; }
    public int Timeout { get; set; }
}