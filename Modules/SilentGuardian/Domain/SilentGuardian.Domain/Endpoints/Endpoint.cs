using System.Net;
using SilentGuardian.Domain.Checks;

namespace SilentGuardian.Domain.Endpoints;

public class Endpoint
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string IpAddress { get; private set; }
    public string? Description { get; private set; }
    public bool IsEnabled { get; private set; }
    public EndpointResult Result { get; private set; }
    public List<CheckMethod> CheckMethods { get; private set; } = default!;
    public int Timeout { get; private set; }
    
    // EF
    public Guid? EndpointGroupId  { get; private set; }
    public EndpointGroup? EndpointGroup { get; private set; }
    
    public static Endpoint Create(string name,string ip, string? description = null, bool isEnabled = true, int timeout = 1000)
    {
        var endpoint = new Endpoint();
        endpoint.Id = Guid.NewGuid();
        endpoint.SetName(name);
        endpoint.SetTimeout(timeout);
        endpoint.IsEnabled = isEnabled;
        endpoint.Description = description;
        endpoint.SetIp(ip);
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
    
    private void SetIp(string ip)
    {
        if (IPAddress.TryParse(ip, out _))
            IpAddress = ip;
        else
            throw new ArgumentException("IP must be a valid IPv4 address.", nameof(ip));
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