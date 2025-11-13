namespace SilentGuardian.Application.DTOs.Endpoints;

public class CheckMethodDTO
{
    public Guid Id { get; protected set; }
    public bool LastResult { get; private set; }
    public DateTime LastCheck { get; private set; }
    public int TimeoutLimit { get; private set; }
    public int Timeout { get; private set; }
}