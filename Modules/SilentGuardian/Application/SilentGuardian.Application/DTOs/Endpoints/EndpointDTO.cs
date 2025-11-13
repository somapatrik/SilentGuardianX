namespace SilentGuardian.Application.DTOs.Endpoints;

public class EndpointDTO
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public bool IsEnabled { get; private set; }
    public EndpointResultDTO Result { get; private set; }
    public List<CheckMethodDTO> CheckMethods { get; private set; } = default!;
    public int Timeout { get; private set; }
}