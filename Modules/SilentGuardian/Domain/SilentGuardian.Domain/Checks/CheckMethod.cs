namespace SilentGuardian.Domain.Checks;

public abstract class CheckMethod
{
    public bool LastResult { get; private set; }
    public DateTime LastCheck { get; private set; }
    public abstract Task CheckAsync();
    
    
}