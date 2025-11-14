namespace SilentGuardian.Application.DTOs.Endpoints;

public class CheckMethodDTO
{
    public Guid Id { get; set; }
    public bool LastResult { get; set; }
    public DateTime LastCheck { get; set; }
    public int TimeoutLimit { get; set; }
    public int Timeout { get; set; }
}