namespace SilentGuardian.Domain.Endpoints;

public class Endpoint
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsEnabled { get; private set; }
    public EndpointResult Result { get; private set; }
}