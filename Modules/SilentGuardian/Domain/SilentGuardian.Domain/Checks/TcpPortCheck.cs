using System.Net;
using System.Net.Sockets;

namespace SilentGuardian.Domain.Checks;

public class TcpPortCheck : CheckMethod
{
    public string IP { get; private set; }
    public int Port { get; private set; }

    public static TcpPortCheck Create(string ip, int port, int timeout = 2000)
    {
        TcpPortCheck check = new TcpPortCheck();
        check.SetIP(ip);
        check.SetPort(port);
        return check;
    }

    private void SetPort(int port)
    {
        if (port < 0 || port > 65535)
            throw new ArgumentOutOfRangeException(nameof(port));
        
        Port = port;
    }

    private void SetIP(string ip)
    {
        if (!IPAddress.TryParse(ip, out _))
            throw new ArgumentException("Invalid IPv4 address", nameof(ip));
        
        IP = ip;
    }

    public override async Task<bool> RunAsync()
    {
        bool result = false;
        try
        {
            using var client = new TcpClient();
            var connectTask = client.ConnectAsync(IP, Port);
            var timeoutTask = Task.Delay(Timeout);

            var completed = await Task.WhenAny(connectTask, timeoutTask);
            result = completed == connectTask && client.Connected;
        }
        catch
        {
            result = false;
        }
        finally
        {
            SetLastResult(result);
        }
        return result;
    }
}