using SilentGuardian.Domain.Checks;

namespace SilentGuardian.Domain.Endpoints;

public class Endpoint
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public bool IsEnabled { get; private set; }
    public EndpointResult Result { get; private set; }
    public List<CheckMethod> CheckMethods { get; private set; } = new List<CheckMethod>();
    public int Timeout { get; private set; }
    
    public static Endpoint Create(string name, string? description = null, bool isEnabled = true, int timeout = 1000)
    {
        var endpoint = new Endpoint();
        endpoint.Id = Guid.NewGuid();
        endpoint.SetName(name);
        endpoint.SetTimeout(timeout);
        endpoint.IsEnabled = isEnabled;
        endpoint.Description = description;
        return endpoint;
    }

    public void Run()
    {
        var tasks = new List<Task>();
        CheckMethods.ForEach(cm => tasks.Add(cm.RunAsync())); 
    }

    public void AddCheckMethod(CheckMethod checkMethod)
    {
        if (CheckMethods.Contains(checkMethod)) return;
        
        if (checkMethod.TimeoutLimit > Timeout)
            checkMethod.SetTimeoutLimit(Timeout);
        
        CheckMethods.Add(checkMethod);
    }

    public void RemoveCheckMethod(CheckMethod checkMethod)
    {
        CheckMethods.Remove(checkMethod);
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
        
        if (name.Length > 50)
            throw new ArgumentException("Name cannot be longer than 50 characters.", nameof(name));
        
        Name = name.Trim();
    }
    private void SetTimeout(int timeout)
    {
        if (timeout <= 0)
            throw new ArgumentException("Timeout must be greater than or equal to 1.", nameof(timeout));
        
        Timeout = timeout;
        
        SetTimeoutLimitForMethods();
    }
    
    private void SetTimeoutLimitForMethods()
    {
        foreach (var checkMethod in CheckMethods)
            if (checkMethod.TimeoutLimit > Timeout)
                checkMethod.SetTimeoutLimit(Timeout);
    }
}