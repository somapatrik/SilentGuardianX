using SilentGuardian.Domain.Endpoints;

namespace SilentGuardian.Domain.Checks;

public abstract class CheckMethod
{
    public Guid Id { get; protected set; }
    public bool LastResult { get; private set; }
    public DateTime LastCheck { get; private set; }
    public int TimeoutLimit { get; private set; }
    public int Timeout { get; private set; }
    public abstract Task<bool> RunAsync();
    
    // EF
    public Guid EndpointId { get; private set; }
    public Endpoint Endpoint { get; private set; } = default!;
    
    public void SetTimeoutLimit(int timeout)
    {
        if (timeout <= 0)
            throw new ArgumentOutOfRangeException(nameof(timeout));
        
        TimeoutLimit = timeout;
    }

    protected void SetTimeout(int timeout)
    {
        if (timeout > TimeoutLimit)
            Timeout = TimeoutLimit;
        
        Timeout = timeout;
    }

    protected void SetLastResult(bool result)
    {
        LastResult = result;
        LastCheck = DateTime.Now;
    }
}